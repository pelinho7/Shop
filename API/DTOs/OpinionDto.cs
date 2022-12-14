using System;

namespace API.DTOs
{
    public class OpinionDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ProductId { get; set; }
        public bool Deleted { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public OpinionLikeDto CurrentUserOpinionLike { get; set; }
        public int OpinionLikesNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModDate { get; set; }
    }
}