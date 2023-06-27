using BixbyShop_LK.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Models.Comments.Services
{
    public class CommentService
    {
        private readonly IMongoCollection<Comment> commentCollection;

        public CommentService(MongoDbContext mongoDbContext)
        {
            commentCollection = mongoDbContext.Comments;
        }

        public List<Comment> GetAllComments()
        {
            return commentCollection.Find(_ => true).ToList();
        }

        public Comment GetCommentById(string commentId)
        {
            var objectId = new ObjectId(commentId);
            return commentCollection.Find(comment => comment.Id == objectId).FirstOrDefault();
        }

        public void CreateComment(Comment comment)
        {
            commentCollection.InsertOne(comment);
        }

        public void UpdateComment(string commentId, Comment updatedComment)
        {
            var objectId = new ObjectId(commentId);
            commentCollection.ReplaceOne(comment => comment.Id == objectId, updatedComment);
        }

        public void DeleteComment(string commentId)
        {
            var objectId = new ObjectId(commentId);
            commentCollection.DeleteOne(comment => comment.Id == objectId);
        }
    }
}
