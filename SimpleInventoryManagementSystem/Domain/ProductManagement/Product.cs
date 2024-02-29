﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInventoryManagementSystem.Domain.InventoryManagemnt;
using SimpleInventoryManagementSystem.Domain.ProductManagement;
namespace SimpleInventoryManagementSystem.Domain.ProductManagement
{
    internal class Product
    {
        private String name;
        private int price;
        private int quantity;
       internal String Name {
            get { 
                return name;
            }
            set { 
                ValidateName(value);
                name = value;
            }
       }
       internal int Price {
            get {
                return price;
            }
            set {
                ValidatePrice(value);
                price = value;
            } 
       }
        internal int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                ValidateQuantity(value);
                quantity = value;
            }
        }
       internal Product(String name,int price,int quantity) {
            ValidateName(name);
            ValidatePrice(price);
            ValidateQuantity(quantity);
            this.price = price;
            this.quantity = quantity;
            this.name = name;
       }
        internal static void ValidateName(String name) {
            if (String.IsNullOrEmpty(name)) { 
                throw new ArgumentNullException("name");
            }
            if (Inventory.IsProductNameAlreadyUsed(name))
            {
                throw new ArgumentException("There is a product with this name");
            }
        }
        internal static void ValidatePrice(int price)
        {
            if(price < 0)
            {
                throw new ArgumentOutOfRangeException("Price must be bigger or equal to zero");
            }
            return;
        }
        internal static void ValidateQuantity(int quantity) {
            if (quantity < 0) {
                throw new ArgumentOutOfRangeException("Quantity must be bigger or equal to zero");
            }
        }
    }
}