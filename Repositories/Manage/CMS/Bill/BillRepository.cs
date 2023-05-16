using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly IBaseRepository _baseRepository;
        public BillRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Create(Bill requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@IdUser", requestModel.IdUser);
                param.Add("@UserName", requestModel.UserName);
                param.Add("@NameReceiver", requestModel.NameReceiver);
                param.Add("@Email", requestModel.Email);
                param.Add("@Address", requestModel.Address);
                param.Add("@Phone", requestModel.Phone);
                param.Add("@IdPro", requestModel.IdPro);
                param.Add("@Product", requestModel.Product);
                param.Add("@Quantity", requestModel.Quantity);
                param.Add("@Price", requestModel.Price);
                param.Add("@ColorId", requestModel.ColorId);
                param.Add("@SizeId", requestModel.SizeId);
                param.Add("@Payments", requestModel.Payments);
                param.Add("@Status", requestModel.Status);
                param.Add("@Describe", requestModel.Describe);
                param.Add("@Total", requestModel.Total);
                param.Add("@TotalNew", requestModel.TotalNew);



                return await _baseRepository.GetValue<int>("[dbo].[Bill_Create]", param);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return 0;
            }
        }

        public async Task<int> Update(Bill requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                param.Add("@Status", requestModel.Status);
               

                return await _baseRepository.GetValue<int>("[dbo].[Bill_Update]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        

        public async Task<BillPaging> GetByUser(BillRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                var model = new BillPaging();
                model.lst = await _baseRepository.GetList<Bill>("[dbo].[Bill_GetByUser]", param);
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }
        public async Task<BillPaging> GetAll(BillRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@pageIndex", requestModel.Page);
                param.Add("@pageSize", requestModel.PageSize);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new BillPaging();
                model.lst = await _baseRepository.GetList<Bill>("[dbo].[Bill_GetAll]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR" + ex.Message);
                return null;
            }
        }
    }
}
