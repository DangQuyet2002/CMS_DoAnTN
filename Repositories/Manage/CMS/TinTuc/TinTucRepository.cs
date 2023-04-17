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
    public class TinTucRepository : ITinTucRepository
    {
        private readonly IBaseRepository _baseRepository;

        public TinTucRepository (IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<int> Create(TinTucModel requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Content", requestModel.Content);
                param.Add("@Title", requestModel.Title);
                param.Add("@Image", requestModel.Image);
                param.Add("@Status", requestModel.Status);
                var model = new TinTucPaging();
                return await _baseRepository.GetValue<int>("[dbo].[TinTuc_Create]", param);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<int> Delete(TinTucRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ListIds", requestModel.ListId);
                var model = new TinTucPaging();
                return await _baseRepository.GetValue<int>("[dbo].[TinTuc_Delete]", param);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<TinTucPaging> GetAll(TinTucRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@pageIndex", requestModel.Page);
                param.Add("@pageSize", requestModel.PageSize);
                param.Add("@totalCount", 0 , System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new TinTucPaging();
                model.lst = await _baseRepository.GetList<TinTucModel>("TinTuc_GetAll", param);
                model.totalCont = param.Get<int>("@totalCount");
                return model;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }

        }

        public async Task<TinTucModel> GetById(int Id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", Id);
                var model = await _baseRepository.GetList<TinTucModel>("[dbo].[TinTuc_GetById]", param);
                return model.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        public async Task<TinTucPaging> SelectAll()
        {
            try
            {
                var param = new DynamicParameters();
                var model = new TinTucPaging();
                model.lst = await _baseRepository.GetList<TinTucModel>("TinTuc_SelectAll", param);
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }

        }

        public async Task<int> Update(TinTucModel requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Content", requestModel.Content);
                param.Add("@Title", requestModel.Title);
                param.Add("@Image", requestModel.Image);
                param.Add("@Id", requestModel.Id);
                var model = new TinTucPaging();
                return await _baseRepository.GetValue<int>("[dbo].[TinTuc_Update]", param);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
    }
}
