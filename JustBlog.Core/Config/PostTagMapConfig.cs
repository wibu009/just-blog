using JustBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustBlog.Core.Config
{
    public class PostTagMapConfig : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.ToTable("PostTagMaps");
            builder.HasKey(ptm => new { ptm.PostId, ptm.TagId });
            builder.HasOne(ptm => ptm.Post)
                .WithMany(p => p.PostTagMaps)
                .HasForeignKey(ptm => ptm.PostId);
            builder.HasOne(ptm => ptm.Tag)
                .WithMany(t => t.PostTagMaps)
                .HasForeignKey(ptm => ptm.TagId);
        }
    }
}
