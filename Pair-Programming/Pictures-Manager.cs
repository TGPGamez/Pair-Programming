using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pair_Programming
{
    static public class Pictures_Manager
    {
        const string diretory_path = @"C:\Users\Tobias\Desktop\Backgrounds";

        static private List<PictureModel> picturePaths;

        //Stores all pictures from directory
        static public List<PictureModel> PicturePaths
        {
            get { return picturePaths; }
            private set { picturePaths = value; }
        }

        /// <summary>
        /// Add Picture to list and directory
        /// </summary>
        /// <param name="pictureModel"></param>
        static public void AddPicture(PictureModel pictureModel) 
        {
            //Copy and paste picture to directory
            File.Copy(pictureModel.Path, $@"{diretory_path}\{pictureModel.Name}", true);
            //Add to list
            picturePaths.Add(pictureModel);
        }

        /// <summary>
        /// Remove Picture from list and directory
        /// </summary>
        /// <param name="pictureModel"></param>
        static public void RemovePicture(PictureModel pictureModel)
        {
            //Remove picture from directory
            File.Delete(pictureModel.Path);
            //Remove from list
            picturePaths.Remove(picturePaths.Where(x => x.Name == pictureModel.Name).First());
        }

        static int countOfIndex = 1;

        /// <summary>
        /// Timer set background
        /// </summary>
        static public void TimerSetBackgrund() 
        {
            Background_Handler.SetBackground(picturePaths[countOfIndex - 1 ].Path);
            if (countOfIndex < picturePaths.Count)
            {
                countOfIndex++;
            }
            else
            {
                countOfIndex = 1;
            }


        }

        /// <summary>
        /// Loads all pictures
        /// </summary>
        static public void LoadPictures()
        {
            picturePaths = new List<PictureModel>();
            //Loops all pathes from directory
            foreach (string filePath in Directory.GetFiles(diretory_path)) {
                string pattern = @"([^\\]+$)";
                RegexOptions options = RegexOptions.Singleline;

                //Uses Reegex to get "name" -> after last /
                //Example: "../../../Backgrounds/Testing.png" would give "Testing.png"
                Match m = Regex.Match(filePath, pattern, options);
                if (m.Success)
                {
                    //Add to list
                    PictureModel pictureModel = new PictureModel(m.Groups[1].Value, filePath);
                    picturePaths.Add(pictureModel);
                }
            }
        }
    }
}
