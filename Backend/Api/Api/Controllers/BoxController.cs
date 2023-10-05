﻿using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class BoxController
{
    private readonly Service.Service _service;

    public BoxController(Service.Service service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/createBox")]
    public Box CreateBox([FromBody] Box box)
    {
        return _service.CreateBox(box.Title, box.Description, box.Price, box.ImageURL, box.Length, box.Width,
            box.Height);
    }

    [HttpGet]
    [Route("/products")]
    public IEnumerable<Box> GetAllProducts()
    {
        IEnumerable<Box> boxes = _service.GetAllProducts();

        return boxes;
    }

    [HttpGet]
    [Route("/products/{productID}")]
    public Box GetProductById([FromRoute] int productID)
    {
        return _service.GetBoxById(productID);
    }
    
    
        
    [HttpDelete]
    [Route("/api/products/{id}")]
    public bool DeleteArticle([FromHeader] int id)
    {
        return _service.DeleteBox(id);
    }
    
    [HttpPut]
    [Route("/api/products")]
    public Box UpdateArticle([FromBody] Box box)
    {
        return _service.UpdateBox(box);
    }
}