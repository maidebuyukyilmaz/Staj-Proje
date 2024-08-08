using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DTO.DTOs.CommentDtos;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager(ICommentRepository _commentRepository,IMapper _mapper) : ICommentService
    {
        
        public async Task<bool> TCreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var comment = _mapper.Map<Comment>(createCommentDto);
           return await _commentRepository.CreateAsync(comment);
        }

        public  async Task<bool> TDeleteCommentAsync(int commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);


            if (comment.ParentCommentId == null)
            {
                // Ana yorum siliniyor, tüm yanıtları da sil
                var replies = await _commentRepository.GetRepliesByParentCommentIdAsync(commentId);
                foreach (var reply in replies)
                {
                    await _commentRepository.DeleteAsync(reply.CommentId);
                }
            }

            // Yorumu sil
           return await _commentRepository.DeleteAsync(commentId);
        }

        public async Task<List<CommentDto>> TGetCommentsByBlogIdAsync(int blogId)
        {
            var comments = await _commentRepository.GetCommentsByBlogIdAsync(blogId);
            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<List<CommentDto>> TGetRepliesByCommentIdAsync(int commentId)
        {
            var replies = await _commentRepository.GetRepliesByParentCommentIdAsync(commentId);
            return _mapper.Map<List<CommentDto>>(replies);
        }

        public async Task<bool> TReplyToCommentAsync(ReplyToCommentDto replyToCommentDto)
        {
            var comment = _mapper.Map<Comment>(replyToCommentDto);
            return await _commentRepository.CreateAsync(comment);
        }

        public async Task<bool> TUpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var comment = _mapper.Map<Comment>(updateCommentDto);
            return await _commentRepository.UpdateAsync(comment);
        }
    }
}
