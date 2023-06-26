using BixbyShop_LK.Models.Comments;

namespace BixbyShop_LK.Services
{
    public class CommentService
    {
        private readonly AppDbContext _dbContext;

        public CommentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Comment> GetAllComments()
        {
            return _dbContext.Comments.ToList();
        }

        public Comment GetCommentById(long id)
        {
            return _dbContext.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void CreateComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }
    }
}
