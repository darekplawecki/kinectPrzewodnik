using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Przewodnik.Models;
using Przewodnik.Content.Attractions;

namespace Przewodnik.ViewModels
{
    public class AttractionViewModel
    {

        private AttractionModel model;

        public AttractionViewModel(string parameter)
        {
            model = new AttractionModel();
            model.Title = AttractionContent.getTitleFor(parameter);
            model.Description = AttractionContent.getDescriptionFor(parameter);
            model.Photos = AttractionContent.getPhotosFor(parameter);
            model.Camera = AttractionContent.getCameraFor(parameter);
        }

        public AttractionModel GetModel()
        {
            return model;
        }

    }
}
