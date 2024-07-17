using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO;
using WebApiExample.Core.DTO.Pagination;

namespace WebApiExample.Core.Interfaces;

public interface IAdminVendorService
{
    /// <summary>
    /// Get list of vendor using filtering and paging
    /// </summary>
    /// <param name="searchModel"></param>
    /// <returns></returns>
    IPagedList<VendorDto> GetList(SearchVendorDto searchModel);

    /// <summary>
    /// Create new Vendor
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntityAlreadyExistsException">Thrown if vendor already exists with such name</exception>
    Task<VendorDto> CreateAsync(VendorCreateDto model);

    /// <summary>
    /// Update existing Vendor
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="EntityAlreadyExistsException">Thrown if vendor already exists with such name and has another id than passed</exception>
    /// <exception cref="EntityNotFoundException">Thrown if vendor is not found by passed id</exception>
    Task UpdateAsync(VendorUpdateDto model);

    /// <summary>
    /// Delete existing Vendor
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException">Thrown if vendor is not found by passed id</exception>
    Task DeleteAsync(int id);
}
