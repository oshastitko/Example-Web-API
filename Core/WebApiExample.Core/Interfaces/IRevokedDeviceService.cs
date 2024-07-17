using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO;
using WebApiExample.Core.DTO.Pagination;
using WebApiExample.Core.DTO.RevokedDevices;
using WebApiExample.Core.DTO.Search;

namespace WebApiExample.Core.Interfaces;

public interface IRevokedDeviceService
{
    /// <summary>
    /// Get device list using filtering and paging
    /// </summary>
    /// <param name="searchModel"></param>
    /// <returns></returns>
    IPagedList<RevokedDeviceDto> GetDevices(SearchRevokedDeviceDto searchModel);

    /// <summary>
    /// Get history of concrete device using paging
    /// </summary>
    /// <param name="deviceId"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    IPagedList<RevokedDeviceHistoryItemDto> GetDeviceHistory(int deviceId);

    /// <summary>
    /// Link device to vendor. If the device is already linked to the vendor - nothing happened
    /// </summary>
    /// <param name="id"></param>
    /// <param name="vendorId"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    Task LinkDeviceToVendorAsync(int id, int vendorId);

    /// <summary>
    /// Link suite of devices to vendor
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="vendorId"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException">Thrown if vendor is not found by passed id</exception>
    Task<List<int>> LinkDevicesToVendorAsync(int[] ids, int vendorId);

    /// <summary>
    /// Unlink device from vendor. If the device is not linked to any vendor - nothing happened
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    Task UnlinkDeviceFromVendorAsync(int id);

    /// <summary>
    /// Unlink the suite of devices from vendors
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<List<int>> UnlinkDevicesFromVendorAsync(int[] ids);

    /// <summary>
    /// Mark/unmark address of device as virtual
    /// </summary>
    /// <param name="id"></param>
    /// <param name="virtualAddress"></param>
    /// <returns></returns>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    Task SetDeviceVirtualAddressAsync(int id, bool virtualAddress);

    /// <summary>
    /// Mark/unmark addresses of the suite of devices as virtual
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="virtualAddress"></param>
    /// <returns></returns>
    Task<List<int>> SetDevicesVirtualAddressAsync(int[] ids, bool virtualAddress);
}
