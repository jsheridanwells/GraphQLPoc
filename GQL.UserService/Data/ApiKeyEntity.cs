using System;
using System.Collections.Generic;

namespace GQL.UserService.Data
{
    public class ApiKeyEntity
    {
        public Guid Id { get; set;  }
        public string Owner { get; set; }
        public string Key { get; set; }
        public DateTime CreatedDate { get; set; }
        public IReadOnlyCollection<string> Roles { get; set; }

        public ApiKeyEntity(
            Guid id,
            string owner,
            string key,
            DateTime createdDate,
            IReadOnlyCollection<string> roles
        )
        {
            Id = id;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            CreatedDate = createdDate;
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        // TODO : I think I need this to work w/ EF Core....
        public ApiKeyEntity() { }
    }
}
