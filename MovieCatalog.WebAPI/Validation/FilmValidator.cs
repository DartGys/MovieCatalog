﻿using MovieCatalog.BLL.Models;

namespace MovieCatalog.WebAPI.Validation
{
    public static class FilmValidator
    {
        public static string Validation(FilmModel model)
        {
            string error = string.Empty;

            if (model == null)
            {
                error = "Film model is null";
            }

            else if (string.IsNullOrWhiteSpace(model.Name))
            {
                error = "Film name is empty or whitespace";
            }

            else if (string.IsNullOrWhiteSpace(model.Director))
            {
                error = "Film director is empty or whitespace";
            }

            return error;
        }
    }
}