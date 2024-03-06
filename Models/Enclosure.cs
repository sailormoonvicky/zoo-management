using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models;

public class Enclosure
{
    public int Id { get; set;} // Enclosure Id
    public required string Name { get; set;} // Lion (10), Aviary (50), Reptile (40), Giraffe (6), Hippo (10)

}

// public class Post
// {
//     public int Id { get; set; }
//     public ICollection<Comment> Comments { get; set; }
// }

// public class Comment
// {
//     public int Id { get; set; }
//     public int PostId { get; set; }
//     [InverseProperty("Comments")]
//     public Post Post { get; set; }
//     public int? ParentCommentId { get; set; }
//     [InverseProperty("RepliedToComment")]
//     public Comment RepliedToComment { get; set; }
//     [InverseProperty("ParentComment")]
//     public ICollection<Comment> Replies { get; set; }
// }



// public decimal Balance => InTransactions.Sum(transaction => transaction.Amount) - OutTransactions.Sum(transaction => transaction.Amount);


// id Name     SpeciesId NumberofAnimal
// 1   LionKingdom 1       10