using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductLikeRepository : IGioHangRepository
    {
        private readonly IBaseRepository _baseRepository;
        public ProductLikeRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Create(GioHang requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ProductId", requestModel.ProductId);
                param.Add("@UserId", requestModel.UserId);
                param.Add("@ProductName", requestModel.ProductName);
                param.Add("@Image", requestModel.Image);
                param.Add("@Quantity", requestModel.Quantity);
                param.Add("@Price", requestModel.Price);
                param.Add("@ColorId", requestModel.ColorId);
                param.Add("@SizeId", requestModel.SizeId);
                param.Add("@Status", requestModel.Status);
                param.Add("@Total", requestModel.Total);
                return await _baseRepository.GetValue<int>("[dbo].[ProductLike_Create]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return 0;
            }
        }

        public async Task<int> DeleteAll(GioHangRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ListIds", requestModel.ListId);
                return await _baseRepository.GetValue<int>("[dbo].[Detail_DeleteAll]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return 0;
            }
        }
        public async Task<int> Delete(GioHangRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                return await _baseRepository.GetValue<int>("[dbo].[Detail_Delete]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return 0;
            }
        }

        public async Task<GioHangPaging> GetByUser(GioHangRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                var model = new GioHangPaging();
                model.lst = await _baseRepository.GetList<GioHang>("[dbo].[GioHang_GetById]", param);
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }
        public async Task<GioHang> GetById(int Id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", Id);
                var model = await _baseRepository.GetList<GioHang>("[dbo].[GioHang_GetById]", param);
                return model.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }

        public async Task<GioHang> GetByIdBill(int Id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", Id);
                var model = await _baseRepository.GetList<GioHang>("[dbo].[GioHang_GetByIdBill]", param);
                return model.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }
        public async Task<GioHangPaging> GetListByUser(GioHangRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ListIds", requestModel.ListId);
                var model = new GioHangPaging();
                model.lst = await _baseRepository.GetList<GioHang>("[dbo].[GioHang_GetListByUser]", param);
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }
        public async Task<int> Update(GioHang requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);

                param.Add("@SizeId", requestModel.SizeId);


                return await _baseRepository.GetValue<int>("[dbo].[Cart_Update]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
        public async Task<int> UpdateColor(GioHang requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);

                param.Add("@ColorId", requestModel.ColorId);


                return await _baseRepository.GetValue<int>("[dbo].[Cart_UpdateColor]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
        public async Task<int> UpdateQuantity(GioHang requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);

                param.Add("@Quantity", requestModel.Quantity);


                return await _baseRepository.GetValue<int>("[dbo].[Cart_UpdateQuantity]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
    }
}
