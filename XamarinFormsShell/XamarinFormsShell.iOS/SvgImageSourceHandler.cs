using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportImageSourceHandler(typeof(SvgImageSource), typeof(XamarinFormsShell.iOS.SvgImageSourceHandler))]
namespace XamarinFormsShell.iOS
{
	/// <summary>
	/// Svg image source handler.
	/// </summary>
	public class SvgImageSourceHandler : IImageSourceHandler
	{
		/// <summary>
		/// Loads the image async.
		/// </summary>
		/// <returns>The image async.</returns>
		/// <param name="imagesource">Imagesource.</param>
		/// <param name="cancelationToken">Cancelation token.</param>
		/// <param name="scale">Scale.</param>
		public async Task<UIImage> LoadImageAsync(ImageSource imagesource, CancellationToken cancelationToken = default(CancellationToken), float scale = 1)
		{
			try
			{
				if (imagesource is SvgImageSource svgSource)
				{
					var embeddedSource = (EmbeddedResourceImageSource)svgSource.ImageSource;
					
					return await ImageService.Instance.LoadEmbeddedResource(embeddedSource.Uri.AbsoluteUri).AsUIImageAsync();
				}

			}
			catch (Exception exception)
			{
				//Since developers can't catch this themselves, I think we should log it and silently fail
				Debug.WriteLine("Unexpected exception in FFImageLoading image source handler: {0}", exception);
			}

			return default(UIImage);
		}
	}
}