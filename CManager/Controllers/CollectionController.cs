using System.Text;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using CManager.Models;
using CManager.ViewModels;
using Dropbox.Api.TeamCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CManager.Controllers;

public class CollectionController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _config;
    private UserManager<User> _userManager;
    private ApplicationDbContext _context;

    public CollectionController(ApplicationDbContext context, IConfiguration config, UserManager<User> userManager)
    {
        _db = context;
        _config = config;
        _userManager = userManager;
        _context = context;
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult CreateCollection()
    {
        return View();
    }

    [HttpGet]
    [Route("Collection/{collectionId:int}")]
    public IActionResult Collection(int collectionId)
    {
        return View(_db.Collections.FirstOrDefault(c => c.Id == collectionId));
    }
    
    [HttpGet]
    [Route("Collection/{collectionId:int}/edit")]
    public IActionResult EditCollectionView(int collectionId)
    {
        Collection collection = _db.Collections.FirstOrDefault(c => c.Id == collectionId);
        CreateCollectionViewModel collectionViewModel = new CreateCollectionViewModel
        {
            Id = collectionId,
            AuthorId = collection.AuthorId,
            Title = collection.Title,
            Description = collection.Description,
            Theme = collection.Theme,
            IncludeDate = collection.AddDates,
            IncludeBrand = collection.AddBrands,
            IncludeComments = collection.AddComments
        };
        return View("EditCollection", collectionViewModel);
    }

    [HttpGet]
    [Route("item/{itemId:int}/Edit")]
    public IActionResult EditItemView(int itemId)
    {
        Item item = _context.Items.First(i => i.Id == itemId);
        ItemViewModel itemViewModel = new ItemViewModel()
        {
            Id = itemId,
            CollectionId = item.CollectionId,
            Title = item.Title,
            Description = item.Description,
            Brand = item.Brand,
            Date = item.Date
        };
        return View("EditItem", itemViewModel);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCollection(CreateCollectionViewModel collectionViewModel)
    {
        if (!ModelState.IsValid || collectionViewModel.Theme == "null") 
            return await Task.Run(() => View(collectionViewModel));

        string? fileName = null;
        
        if (Request.Form.Files.Count != 0)
        {
            var file = Request.Form.Files.First();
            fileName = SaveFileAsync(file).Result;
        }
        else
        {
            fileName = "NoImage.jpg";
        }

        var newCollection = new Collection
        {
            AuthorId = collectionViewModel.AuthorId, 
            Title = collectionViewModel.Title,
            Description = collectionViewModel.Description, 
            Theme = collectionViewModel.Theme,
            AddDates = collectionViewModel.IncludeDate, 
            AddBrands = collectionViewModel.IncludeBrand,
            AddComments = collectionViewModel.IncludeComments, 
            LastEditDate = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm"),
            FileName = fileName
        };
        
        await _db.Collections.AddAsync(newCollection);
        await _db.SaveChangesAsync();
        return await Task.Run(() => Redirect("~/collection/" + newCollection.Id));
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditCollection(CreateCollectionViewModel collectionViewModel)
    {

        string fileName;
        
        if (Request.Form.Files.Count != 0)
        {
            var file = Request.Form.Files.First();
            fileName = SaveFileAsync(file).Result;
        }
        else
        {
            fileName = "NoImage.jpg";
        }

        Collection collection = _context.Collections.Single(c => c.Id == collectionViewModel.Id);
        collection.Id = collectionViewModel.Id;
        collection.Title = collectionViewModel.Title;
        collection.Description = collectionViewModel.Description;
        collection.Theme = collectionViewModel.Theme;
        collection.AddBrands = collectionViewModel.IncludeBrand;
        collection.AddComments = collectionViewModel.IncludeComments;
        collection.LastEditDate = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm");
        collection.FileName = fileName;

        _db.Collections.Update(collection);
        await _db.SaveChangesAsync();
        return await Task.Run(() => Redirect("~/collection/" + collectionViewModel.Id));
    }
    
    [HttpPost]
    //[Route("collection/{collectionId:int}/delete")]
    public IActionResult DeleteCollection(int collectionId)
    {

        var currentUser = _userManager.Users.Single(u => u.Email == User.Identity.Name);
        if (!_userManager.IsInRoleAsync(currentUser, "admin").Result)
        {
            if (_db.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Id !=
                _db.Collections.FirstOrDefault(c => c.Id == collectionId)?.AuthorId)
                return RedirectToAction("Index", "Home");
        }

        Collection? collection = _db.Collections.FirstOrDefault(c => c.Id == collectionId);
        if (collection != null)
        {
            _db.Collections.Remove(collection);
            _db.SaveChanges();
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("item/{itemId:int}")]
    public IActionResult Item(int itemId)
    {
        return View(_db.Items.FirstOrDefault(i => i.Id == itemId));
    }
    
    [HttpGet]
    [Route("Collection/{collectionId:int}/AddItem")]
    public IActionResult AddItem(int collectionId)
    {
        var currentUser = _userManager.Users.Single(u => u.Email == User.Identity.Name);
        if (!_userManager.IsInRoleAsync(currentUser, "admin").Result)
        {
            if (_db.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Id !=
                _db.Collections.FirstOrDefault(c => c.Id == collectionId).AuthorId)
                return RedirectToAction("Index", "Home");
        }

        ViewBag.collectionId = collectionId;

        return View();
    }
    
    [Authorize]
    [HttpPost]
    [Route("Collection/{collectionId:int}/AddItem")]
    public async Task<IActionResult> AddItem(ItemViewModel itemViewModel, int collectionId)
    {
        if (!ModelState.IsValid) return await Task.Run(() => View(itemViewModel));

        string FileName;

        if (Request.Form.Files.Count != 0)
            FileName = SaveFileAsync(Request.Form.Files[0]).Result;
        else 
            FileName = "NoImage.jpg";
        

        var newItem = new Item
        {
            CollectionId = itemViewModel.CollectionId, 
            Title = itemViewModel.Title,
            Description = itemViewModel.Description, 
            LastEditDate = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm"),
            Date = itemViewModel.Date, 
            Brand = itemViewModel.Brand, 
            FileName = FileName,
        };
        
        await _db.Items.AddAsync(newItem);
        await _db.SaveChangesAsync();
        return await Task.Run(() => Redirect("~/collection/" + collectionId));
    }
    
    [HttpPost]
    public async Task<IActionResult> EditItem(ItemViewModel itemViewModel)
    {
        if (!ModelState.IsValid) return await Task.Run(() => View(itemViewModel));

        string FileName;

        if (Request.Form.Files.Count != 0)
            FileName = SaveFileAsync(Request.Form.Files[0]).Result;
        else 
            FileName = "NoImage.jpg";

        Item item = _context.Items.Single(i => i.Id == itemViewModel.Id);
        item.Title = itemViewModel.Title;
        item.Description = itemViewModel.Description;
        item.Brand = itemViewModel.Brand;
        item.Date = itemViewModel.Date;
        item.LastEditDate = DateTime.UtcNow.AddHours(3).ToString("MM/dd/yyyy H:mm");
        item.FileName = FileName;
        
        _db.Items.Update(item);
        await _db.SaveChangesAsync();
        return await Task.Run(() => Redirect("~/item/" + itemViewModel.Id));
    }
    
    [HttpPost]
    public IActionResult DeleteItem(int itemId)
    {
        if (_db.Users.FirstOrDefault(u => u.Email == User.Identity.Name).Id !=
            _db.Collections.First(c => c.Id == _db.Items.First(i => i.Id == itemId).CollectionId).AuthorId)
            return RedirectToAction("Index", "Home");

        Item item = _db.Items.First(i => i.Id == itemId);
        int collectionId = item.CollectionId;
        _db.Items.Remove(item);
        _db.SaveChanges();
        return Redirect("~/collection/" + collectionId);
    }

    public async Task PushToCloud(string fileName, string path)
    {
        string connectionString = _config["ConnectionStrings:BlobConnection"];
        var serverClient = new BlobServiceClient(connectionString);
        var containerClient = serverClient.GetBlobContainerClient("images");
        var blobClient = containerClient.GetBlobClient(fileName);
        using FileStream uploadFileStream = System.IO.File.OpenRead(path);
        blobClient.Upload(uploadFileStream, true);
        uploadFileStream.Close();
        System.IO.File.Delete(fileName);
    }

    public static string GetFileName()
    {
        var fileName = Guid.NewGuid().ToString();
        return fileName;
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        var originalFileName = Path.GetFileName(file.FileName);
        string extension = originalFileName.Substring(originalFileName.LastIndexOf('.') + 1, originalFileName.Length - 1 - originalFileName.LastIndexOf('.'));
        var uniqueFileName = GetFileName();

        using (var stream = System.IO.File.Create(uniqueFileName + '.' + extension))
            await file.CopyToAsync(stream);
        
        string resultingName = uniqueFileName + '.' + extension;
        await PushToCloud(resultingName, resultingName);
        return resultingName;
    }
    
    
}