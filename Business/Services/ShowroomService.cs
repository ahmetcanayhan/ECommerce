using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Responses;

namespace Business.Services
{
    public class ShowroomService : IShowroomService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ShowroomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IResult<IEnumerable<ProductListItemDto>>> GetProductsAsync()
        {
            var result = await unitOfWork.ProductRepository.FindManyAsync(x => x.Active && !x.Deleted, "Subcategory.Category", "Brand", "Images", "Reviews");
            if (result.IsSuccess)
            {
                var products = mapper.Map<IEnumerable<ProductListItemDto>>(result.Data);
                return Result<IEnumerable<ProductListItemDto>>.Success(products);
            }
            return Result<IEnumerable<ProductListItemDto>>.Failure(result.Errors, result.StatusCode);
        }
    }
}
