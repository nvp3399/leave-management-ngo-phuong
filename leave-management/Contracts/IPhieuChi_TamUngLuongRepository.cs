﻿using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IPhieuChi_TamUngLuongRepository : IRepositoryStringKeyBase<PhieuChi_TamUngLuong>
    {
        public Task<PhieuChi_TamUngLuong> FindByMaYeuCauTamUng(string maYeuCauTamUng);
    }
}
