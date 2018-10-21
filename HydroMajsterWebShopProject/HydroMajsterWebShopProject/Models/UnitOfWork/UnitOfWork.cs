using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.Repositories;

namespace HydroMajsterWebShopProject.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private readonly DatabaseContext _databaseContext;
        private ProductRepository _productRepository;
        private ProductQuantityRepository _productQuantityRepository;
        private CategoryRepository _categoryRepository;
        private bool disposed = false;
        #endregion
        #region Constructors
        public UnitOfWork(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        #endregion
        #region Properties
        public ProductRepository ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new ProductRepository(_databaseContext);
                }

                return _productRepository;
            }
        }

        public ProductQuantityRepository ProductQuantityRepository
        {
            get
            {
                if (this._productQuantityRepository == null)
                {
                    this._productQuantityRepository = new ProductQuantityRepository(this._databaseContext);
                }

                return this._productQuantityRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new CategoryRepository(this._databaseContext);
                }

                return this._categoryRepository;
            }
        }
        #endregion
        #region Methods
        public void Save() => this._databaseContext.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
