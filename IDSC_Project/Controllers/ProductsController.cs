using AutoMapper;
using IDSC_Project.CORE;
using IDSC_Project.CORE.Models;
using IDSC_Project.CORE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDSC_Project.Controllers;
[Authorize]
public class ProductsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [AllowAnonymous]
    public async Task<IActionResult> Index() =>
       View("GetAllProducts", await _unitOfWork.ProductRepository.GetAllAsync());
    [AllowAnonymous]
    public async Task<IActionResult> Search(string searchKey)
    {
        ViewData["Search"] = searchKey;
        return View("GetAllProducts", await _unitOfWork.ProductRepository.SearchAsync(searchKey));
    }
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {

        Product product = await _unitOfWork.ProductRepository.GetProductAsync(id);
        if (product == null)
            return RedirectToAction(nameof(Index));

        return View(product);
    }
    public async Task<IActionResult> Edit(int id)
    {

        Product product = await _unitOfWork.ProductRepository.GetProductAsync(id);
        if (product == null)
            return RedirectToAction(nameof(Index));

        return View(product);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditProductViewModel viewModel)
    {
        if(!ModelState.IsValid)
            return View(viewModel);

        if (viewModel == null)
            return RedirectToAction(nameof(Index));

        Product product = await _unitOfWork.ProductRepository.GetProductAsync(viewModel.Id);
        if (product == null)
            return RedirectToAction(nameof(Index));

        _mapper.Map(viewModel, product);
        _unitOfWork.ProductRepository.Update(product);
        _unitOfWork.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Create()
        => View();
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        Product product = _mapper.Map<Product>(viewModel);

        _unitOfWork.ProductRepository.CreateAsync(product);
        _unitOfWork.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        Product product = await _unitOfWork.ProductRepository.GetProductAsync(id);

        if (product == null)
            return RedirectToAction(nameof(Index));

        _unitOfWork.ProductRepository.DeleteAsync(id);
        _unitOfWork.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}