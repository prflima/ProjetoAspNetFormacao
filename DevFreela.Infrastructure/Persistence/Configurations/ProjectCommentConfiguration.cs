using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
				.HasKey(pc => pc.Id);
			
			builder
				.HasOne(p => p.Project)
				.WithMany(p => p.Comments)
				.HasForeignKey(p => p.IdProject);
			
			builder
				.HasOne(p => p.User)
				.WithMany(p => p.Comments)
				.HasForeignKey(p => p.IdUser);
        }
    }
}