﻿using System.ComponentModel.DataAnnotations;

namespace ProductSalesWebApiAssignment.Models
{
    public class Stores
    {
        [Key]
        public int StoreId {  get; set; }
        public string StoreName {  get; set; }
        public long PhoneNumber {  get; set; }
        public string Email {  get; set; }
        public string Street {  get; set; }
        public string City { get; set; }
        public string State {  get; set; }
        public string ZipCode {  get; set; }
    }
}
