using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Framework.Api.Attributes;
using Web.Framework.Api.Core;
using Web.Framework.Api.Models.Common;
using WebApiExample.Core.DTO;
using WebApiExample.Core.Interfaces;

namespace WebApiExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendorController(IVendorService service, IAdminVendorService adminService) : ControllerBase
{
    /// <summary>
    /// Get list of vendors
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Returns vendor list</response>
    [HttpGet]
    public IActionResult List()
    {
        var model = service.GetVendors();
        return new OkObjectResult(model.Select(a => new
        {
            id = a.Key,
            name = a.Value
        }));
    }

    /// <summary>
    /// Create a new vendor
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <response code="201">Returns the newly created vendor</response>
    /// <response code="422">If vendor with such name already exists</response>
    /// <exception cref="EntityAlreadyExistsException">Thrown if vendor already exists with such name</exception>
    [HttpPost]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityAlreadyExists(ErrorResponseKeys.VENDOR_EXISTS, nameof(VendorCreateDto.Name))]
    public async Task<IActionResult> Create(VendorCreateDto model)
    {
        var dto = await adminService.CreateAsync(model);
        return Created(string.Empty, dto);
    }

    /// <summary>
    /// Update existing vendor
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <response code="204">Updated successfully</response>
    /// <response code="422">If another vendor with such name already exists</response>
    /// <response code="422">If vendor with such id is not found</response>
    /// <exception cref="EntityAlreadyExistsException">Thrown if vendor already exists with such name and has another id than passed</exception>
    /// <exception cref="EntityNotFoundException">Thrown if vendor is not found by passed id</exception>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ValidateApiModelState]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityAlreadyExists(ErrorResponseKeys.VENDOR_EXISTS, nameof(VendorUpdateDto.Name))]
    [EntityNotFound(ErrorResponseKeys.VENDOR_NOT_FOUND, nameof(VendorUpdateDto.Id))]
    public async Task<IActionResult> Update(VendorUpdateDto model)
    {
        await adminService.UpdateAsync(model);
        return NoContent();
    }

    /// <summary>
    /// Delete existing vendor
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204">Deleted successfully</response>
    /// <response code="422">If vendor with such id is not found</response>
    /// <exception cref="EntityNotFoundException">Thrown if vendor is not found by passed id</exception>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ValidateApiModelState]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [EntityNotFound(ErrorResponseKeys.VENDOR_NOT_FOUND, nameof(VendorUpdateDto.Id))]
    public async Task<IActionResult> Delete(int id)
    {
        await adminService.DeleteAsync(id);
        return NoContent();
    }

}
