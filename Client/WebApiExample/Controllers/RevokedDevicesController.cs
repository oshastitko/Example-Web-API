using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using Web.Framework.Api.Attributes;
using Web.Framework.Api.Core;
using Web.Framework.Api.Models.Common;
using Web.Framework.Api.Models.Pagination;
using WebApiExample.Core.DTO.RevokedDevices;
using WebApiExample.Core.DTO.Search;
using WebApiExample.Core.Exceptions;
using WebApiExample.Core.Interfaces;

namespace WebApiExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RevokedDevicesController(IRevokedDeviceService service) : ControllerBase
{

    /// <summary>
    /// Get revoked device list based on search parameters
    /// </summary>
    /// <param name="searchModel"></param>
    /// <returns></returns>
    /// <response code="200">Returns list of devices</response>
    /// <response code="400">Invalid parameters</response>
    [HttpGet]
    [ValidateApiModelState]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PagingApi<RevokedDeviceDto, SearchRevokedDeviceDto>), StatusCodes.Status200OK)]
    public IActionResult List([FromQuery] SearchRevokedDeviceDto searchModel)
    {
        var model = service.GetDevices(searchModel);

        PagingApi<RevokedDeviceDto, SearchRevokedDeviceDto> paging = new(model, searchModel)
        {
            Data = model.ToList(),
        };
        return new OkObjectResult(paging);
    }

    /// <summary>
    /// Link revoked device to vendor
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="vendorId"></param>
    /// <returns></returns>
    /// <response code="204">Linked successfully</response>
    /// <response code="422">If vendor with such id is not found</response>
    /// <response code="422">If device with such id is not found</response>
    /// <response code="400">Invalid parameters</response>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    [HttpPut("{deviceId}/link/{vendorId}")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityNotFound(ErrorResponseKeys.DEVICE_NOT_FOUND, nameof(deviceId))]
    public async Task<IActionResult> LinkToVendor(int deviceId, int vendorId)
    {
        await service.LinkDeviceToVendorAsync(id: deviceId, vendorId: vendorId);
        return NoContent();
    }

    /// <summary>
    /// Link array of revoked devices to Vendor
    /// </summary>
    /// <param name="vendorId"></param>
    /// <param name="deviceIds"></param>
    /// <returns></returns>
    /// <response code="204">Linked successfully</response>
    /// <response code="422">If vendor with such id is not found</response>
    /// <response code="400">Invalid parameters</response>
    /// <exception cref="EntityNotFoundException">Thrown if vendor is not found by passed id</exception>
    [HttpPut("batch-link/{vendorId}")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityNotFound(ErrorResponseKeys.VENDOR_NOT_FOUND, nameof(vendorId))]
    public async Task<IActionResult> LinkToVendor(int vendorId, [FromBody] int[] deviceIds)
    {
        await service.LinkDevicesToVendorAsync(ids: deviceIds, vendorId: vendorId);
        return NoContent();
    }

    /// <summary>
    /// Unlink revoked device from Vendor
    /// </summary>
    /// <param name="deviceId"></param>
    /// <returns></returns>
    /// <response code="204">Unlinked successfully</response>
    /// <response code="422">If device with such id is not found</response>
    /// <response code="400">Invalid parameters</response>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    [HttpPut("{deviceId}/unlink")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityNotFound(ErrorResponseKeys.DEVICE_NOT_FOUND, nameof(deviceId))]
    public async Task<IActionResult> UnlinkFromVendor(int deviceId)
    {
        await service.UnlinkDeviceFromVendorAsync(id: deviceId);
        return NoContent();
    }

    /// <summary>
    /// Unlink array of revoked devices from Vendor
    /// </summary>
    /// <param name="deviceIds"></param>
    /// <returns></returns>
    /// <response code="204">Unlinked successfully</response>
    /// <response code="400">Invalid parameters</response>
    [HttpPut("batch-unlink")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UnlinkFromVendors([FromBody] int[] deviceIds)
    {
        await service.UnlinkDevicesFromVendorAsync(ids: deviceIds);
        return NoContent();
    }


    /// <summary>
    /// Set address of revoked device as virtual
    /// </summary>
    /// <param name="deviceId"></param>
    /// <returns></returns>
    /// <response code="204">Set address as virtual successfully</response>
    /// <response code="422">If device with such id is not found</response>
    /// <response code="400">Invalid parameters</response>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    [HttpPut("{deviceId}/virtual")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityNotFound(ErrorResponseKeys.DEVICE_NOT_FOUND, nameof(deviceId))]
    public async Task<IActionResult> SetDeviceVirtualAddress(int deviceId)
    {
        await service.SetDeviceVirtualAddressAsync(id: deviceId, virtualAddress: true);
        return NoContent();
    }

    /// <summary>
    /// Set addresses of array of revoked devices as virtual
    /// </summary>
    /// <param name="deviceIds"></param>
    /// <returns></returns>
    /// <response code="204">Set addresses as virtual successfully</response>
    /// <response code="400">Invalid parameters</response>
    [HttpPut("batch-virtual")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SetDevicesVirtualAddress([FromBody] int[] deviceIds)
    {
        await service.SetDevicesVirtualAddressAsync(ids: deviceIds, virtualAddress: true);
        return NoContent();
    }

    /// <summary>
    /// Set address of revoked device as not virtual
    /// </summary>
    /// <param name="deviceId"></param>
    /// <returns></returns>
    /// <response code="204">Set address as not virtual successfully</response>
    /// <response code="422">If device with such id is not found</response>
    /// <response code="400">Invalid parameters</response>
    /// <exception cref="EntityNotFoundException">Thrown if device is not found by passed id</exception>
    [HttpPut("{deviceId}/notvirtual")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityNotFound(ErrorResponseKeys.DEVICE_NOT_FOUND, nameof(deviceId))]
    public async Task<IActionResult> SetDeviceNotVirtualAddress(int deviceId)
    {
        await service.SetDeviceVirtualAddressAsync(id: deviceId, virtualAddress: false);
        return NoContent();
    }

    /// <summary>
    /// Set addresses of array of revoked devices as not virtual
    /// </summary>
    /// <param name="deviceIds"></param>
    /// <returns></returns>
    /// <response code="204">Set addresses as not virtual successfully</response>
    /// <response code="400">Invalid parameters</response>
    [HttpPut("batch-notvirtual")]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SetDevicesNotVirtualAddress([FromBody] int[] deviceIds)
    {
        await service.SetDevicesVirtualAddressAsync(ids: deviceIds, virtualAddress: false);
        return NoContent();
    }
}
