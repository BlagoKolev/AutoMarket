﻿using AutoMarket.Data.Models;
using AutoMarket.Models.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Services
{
    public interface IVehiclesService
    {
       
        void CreateVehicle(CreateVehicleOfferViewModel offer, string userId, string imagePath);
       ICollection<VehicleOffersAllViewModel> GetAllVehiclesOffers(int id, int itemsPerPage);
        DetailsOfferViewModel GetVehicleOfferById(string offerId);
       // ICollection<MyVehicleOffersViewModel> GetMyVehicleOffers(string userId, int id, int itemsPerPage);


        int GetItemsCount();

    }
}