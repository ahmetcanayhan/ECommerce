using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Repositories;
using Utils.Responses;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext context;

        public UnitOfWork( ShopContext context )
        {
            this.context = context;
        }

        public IProductRepository? productRepository;
        public IProductRepository ProductRepository => productRepository ??= new ProductRepository( context );

        public IProductImageRepository? productImageRepository;
        public IProductImageRepository ProductImageRepository => productImageRepository ??= new ProductImageRepository( context );

        public IProductReviewRepository? productReviewRepository;
        public IProductReviewRepository ProductReviewRepository => productReviewRepository ??= new ProductReviewRepository( context );

        public IProductAttributeRepository? productAttributeRepository;
        public IProductAttributeRepository ProductAttributeRepository => productAttributeRepository ??= new ProductAttributeRepository( context );
        public ICategoryRepository? categoryRepository;
        public ICategoryRepository CategoryRepository => categoryRepository ??= new CategoryRepository(context);

        public ISubcategoryRepository? subcategoryRepository;
        public ISubcategoryRepository SubcategoryRepository => subcategoryRepository ??= new SubcategoryRepository(context);

        public IBrandRepository? brandRepository;
        public IBrandRepository BrandRepository => brandRepository ??= new BrandRepository( context );

        public ICartRepository? cartRepository;
        public ICartRepository CartRepository => cartRepository  ??= new CartRepository( context );

        public ICartItemRepository? cartItemRepository;
        public ICartItemRepository CartItemRepository => cartItemRepository ??= new CartItemRepository(context);

        public async Task<IResult> CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
                return Result.Success(204);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, 500);
            }
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
