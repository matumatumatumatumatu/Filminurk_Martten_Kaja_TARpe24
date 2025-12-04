using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Microsoft.EntityFrameworkCore;

namespace Filminurk.ApplicationServices.Services
{
    public class FavouriteListsServices : IFavouriteListsServices
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFileServices _fileServices;

        public FavouriteListsServices(FilminurkTARpe24Context context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<FavouriteList> DetailsAsync(Guid id)
        {
            var result = await _context.FavouriteLists
                .FirstOrDefaultAsync(x => x.FavouriteListID == id);
            return result;
        }
        public async Task<FavouriteList> Create(FavouriteListDTO dto, List<Movie> selectedMovies)
        {
            FavouriteList newList = new();
            newList.FavouriteListID = Guid.NewGuid();
            newList.ListName = dto.ListName;
            newList.ListDescription = dto.ListDescription;
            newList.ListCreatedAt = dto.ListCreatedAt;
            newList.ListModifiedAt = dto.ListModifiedAt;
            newList.ListDeletedAt = dto.ListDeletedAt;
            newList.ListOfMovies = dto.ListOfMovies;
            await _context.FavouriteLists.AddAsync(newList);
            await _context.SaveChangesAsync();

            //foreach(var movieid  in selectedMovies)
            //{
              //  _context.FavouriteLists.Entry
            //}
            return newList;
        }
        public async Task<FavouriteList> Update(FavouriteListDTO updatedList)
        {
            FavouriteList updatedListInDB = new();

            updatedListInDB.FavouriteListID = updatedList.FavouriteListID;
            updatedListInDB.ListBelongsToUser = updatedList.ListBelongsToUser;
            updatedListInDB.IsMovieOrActor = updatedList.IsMovieOrActor;
            updatedListInDB.ListName = updatedList.ListName;
            updatedListInDB.ListDescription = updatedList.ListDescription;
            updatedListInDB.IsPrivate = updatedList.IsPrivate;
            updatedListInDB.ListOfMovies = updatedList.ListOfMovies;
            updatedListInDB.ListCreatedAt = updatedList.ListCreatedAt;
            updatedListInDB.ListDeletedAt = updatedList.ListDeletedAt;
            updatedListInDB.ListModifiedAt = updatedList.ListModifiedAt;
            _context.FavouriteLists.Update(updatedListInDB);
            await _context.SaveChangesAsync();
            return updatedListInDB;
        }
    }
}
