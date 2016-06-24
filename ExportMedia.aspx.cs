using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

public partial class ExportMedia : System.Web.UI.Page
{

    public void ExportMediaAction(object sender, EventArgs e)
    {
        var database = Database.GetDatabase("master");
        var folder = txtFolder.Text;

        var images = database.SelectItems("/sitecore/media library/" + folder  + "/ descendant::*[@@templatekey='jpeg']");
        String new_file = "";
        var this_path = Server.MapPath("/") + "/export/";

        int counter = 0;
        foreach (var image in images)
        {

            var mediaPath = image.Paths.Path;
            var mediaItem = (MediaItem)image;
            var media = MediaManager.GetMedia(mediaItem);
            var stream = media.GetStream();

            // check for folder
            mediaPath = mediaPath.Replace("/sitecore/media library", "");
            string fullPath = Path.GetFullPath(mediaPath).TrimEnd(Path.DirectorySeparatorChar);
            string projectName = Path.GetFileName(fullPath);

            // check and see if last value is the same as name + don't need to create folder.
            string path = "";
            if (projectName != image.Name)
            {
                path = this_path + mediaPath;
            }
            else
            {   // Real path
                path = this_path + mediaPath;
                path = path.Substring(0, path.Length - projectName.Length);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            new_file = Path.Combine(path, image.Name + ".jpeg");

            using (var targetStream = File.OpenWrite(new_file))
            {
                stream.CopyTo(targetStream);
                targetStream.Flush();
            }

            Response.Write("IMAGE:" + counter + ":" + new_file + " saved<BR>");
            counter += 1;

        }

        if (counter == 0)
        {
            Response.Write("No records were found.");
        }
        else { 
            Response.Write("DONE");
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}