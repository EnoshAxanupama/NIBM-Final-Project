using BixbyShop_LK.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BixbyShop_LK.Models.Comments.Services
{
    public class CommentService
    {
        private readonly IMongoCollection<Comment> commentCollection;

        public CommentService()
        {
            var client = new MongoClient("mongodb://admin:p%40ssw0rd@localhost:27017/?authMechanism=SCRAM-SHA-256");
            var database = client.GetDatabase("BixbyShop_LK");
            commentCollection = database.GetCollection<Comment>("Comments");
        }

        public List<Comment> GetAllComments()
        {
            return commentCollection.Find(_ => true).ToList();
        }

        public Comment GetCommentById(ObjectId commentId)
        {
            return commentCollection.Find(comment => comment.Id == commentId).FirstOrDefault();
        }

        public void CreateComment(Comment comment)
        {
            commentCollection.InsertOne(comment);
        }

        public void UpdateComment(ObjectId commentId, Comment updatedComment)
        {
            commentCollection.ReplaceOne(comment => comment.Id == commentId, updatedComment);
        }

        public void DeleteComment(ObjectId commentId)
        {
            commentCollection.DeleteOne(comment => comment.Id == commentId);
        }
    }
}
