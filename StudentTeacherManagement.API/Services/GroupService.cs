using Microsoft.EntityFrameworkCore;
using StudentTeacherManagement.Core.Interfaces;
using StudentTeacherManagement.Core.Models;
using StudentTeacherManagement.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherManagement.API.Services
{
    public class GroupService : IGroupService
    {
        private readonly DataContext _context;

        public GroupService(DataContext context)
        {
            _context = context;
        }

        #region DQL

        public async Task<IEnumerable<Group>> GetGroups(string? name, int skip, int take, CancellationToken cancellationToken = default)
        {
            var groups = _context.Groups.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                groups = groups.Where(g => g.Name.Contains(name));
            }

            return await groups.OrderBy(g => g.Name)
                .Skip(skip)
                .Take(take)
                .ToArrayAsync(cancellationToken);
        }

        public async Task<Group?> GetGroupById(Guid id, CancellationToken cancellationToken = default)
        {
            var group = await _context.Groups
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);

            return group;
        }

        #endregion

        #region DML

        public async Task<Group> AddGroup(Group group, CancellationToken cancellationToken = default)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group), "Group cannot be null.");
            }

            await _context.AddAsync(group, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return group;
        }

        public async Task AddStudentToGroup(Guid groupId, Guid studentId, CancellationToken cancellationToken = default)
        {
            var group = await _context.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == groupId, cancellationToken);

            if (group is null)
            {
                throw new KeyNotFoundException($"Group with ID {groupId} was not found.");
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == studentId, cancellationToken);

            if (student is null)
            {
                throw new KeyNotFoundException($"Student with ID {studentId} was not found.");
            }

            student.Group = group;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteGroup(Guid id, CancellationToken cancellationToken = default)
        {
            var group = await _context.Groups
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);

            if (group is not null)
            {
                _context.Groups.Remove(group);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}
