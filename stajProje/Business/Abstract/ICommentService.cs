using DTO.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        Task<List<CommentDto>> TGetCommentsByBlogIdAsync(int blogId);
        Task<List<CommentDto>>   TGetRepliesByCommentIdAsync(int commentId);
        Task<bool> TCreateCommentAsync(CreateCommentDto createCommentDto);
        Task<bool> TReplyToCommentAsync(ReplyToCommentDto replyToCommentDto);
        Task<bool> TDeleteCommentAsync(int commentId);
        Task<bool> TUpdateCommentAsync(UpdateCommentDto updateCommentDto);
      
    }
}
