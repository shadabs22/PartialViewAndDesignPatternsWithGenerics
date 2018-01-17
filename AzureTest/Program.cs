using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Program().DownloadFromAzureStorage();
            //new Program().DownloadFileFromBlob("12345.png");
            new Program().UploadToAzureStorage();
            //new Program().DeleteBlob();
            Console.ReadLine();
        }


        private async Task<int> UploadToAzureStorage()
        {
            try
            {
                //  create Azure Storage
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=contosodemo;AccountKey=gApKbiLzjv6z8nQrEQpmHSKWJGSrGtbiu2QILPp+QWXGX83PpSxosipzKtjLoK5rf0pI0QGlXutLPlbJ0xFw6w==");
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=anotherregiondemo;AccountKey=Hl0UiGSqYadHcTMKkK/eYgFoC0hwn3pOAFxbreeInn5oN2yIfBdzfiYAhtZrXlZubvf1RP0V8l7KH9+lYL3omQ==");

                //  create a blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                //  create a container 
                CloudBlobContainer container = blobClient.GetContainerReference("containerone");
                container.Metadata.Add("assetid", "3");

                //  create a block blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("3.jpg");
                blockBlob.Metadata.Add("assetid", "3");
                //  create a local file
                //.StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("123", CreationCollisionOption.ReplaceExisting);

                //  copy some txt to local file
                MemoryStream ms = new MemoryStream();

                //.DataContractSerializer serializer = new DataContractSerializer(typeof(string));
                //.serializer.WriteObject(ms, "Hello Azure World!!");

                //.using (Stream fileStream = await file.OpenStreamForWriteAsync())
                //.{
                //.    ms.Seek(0, SeekOrigin.Begin);
                //.    await ms.CopyToAsync(fileStream);
                //.    await fileStream.FlushAsync();
                //.}

                //  upload to Azure Storage 
                //.await blockBlob.UploadFromFileAsync(file);
                byte[] bytes = ReadImageFile(@"C:\images10.jpg");
                await blockBlob.UploadFromStreamAsync(new MemoryStream(bytes));

                var blobs = container.ListBlobs().OfType<CloudBlockBlob>()
                         .Where(b => b.Metadata["assetid"] == "3").ToList();

                return 1;
            }
            catch(Exception e)
            {
                //  return error
                return 0;
            }
        }

        private async Task<int> DownloadFromAzureStorage()
        {
            try
            {
                //  create Azure Storage
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=universalappazurestorage;AccountKey=H6nuoFWjGTCXYkbgFH+iHtb9+jN//2XYNFqmXI0eEHJPA6wC9LDD46wb7bsYuRo1ZiExr94hpEwxj9OEV1jaOg==");
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=contosodemo;AccountKey=gApKbiLzjv6z8nQrEQpmHSKWJGSrGtbiu2QILPp+QWXGX83PpSxosipzKtjLoK5rf0pI0QGlXutLPlbJ0xFw6w==");
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=anotherregiondemo;AccountKey=Hl0UiGSqYadHcTMKkK/eYgFoC0hwn3pOAFxbreeInn5oN2yIfBdzfiYAhtZrXlZubvf1RP0V8l7KH9+lYL3omQ==");


                //  create a blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                //  create a container 
                CloudBlobContainer container = blobClient.GetContainerReference("containerone");

                //  create a block blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference("12345.png");

                //  create a local file
                //StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("filename_from_azure", CreationCollisionOption.ReplaceExisting);

                //  download from Azure Storage
                byte[] bytes=new byte[16*1024];
                MemoryStream ms = new MemoryStream();
                blockBlob.DownloadToStream(ms);
                bytes = ms.ToArray();
                string result = System.Text.Encoding.UTF8.GetString(bytes);
                string result1 = ms.ToString();             

                return 1;
            }
            catch
            {
                //  return error
                return 0;
            }
        }

        public async Task<byte[]> DownloadFileFromBlob(string FileName)
        {
            // Get Blob Container
            CloudBlobContainer container = BlobUtilities.GetBlobClient.GetContainerReference("containerone");

            // Get reference to blob (binary content)
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FileName);

            // Read content
            using (MemoryStream ms = new MemoryStream())
            {
                blockBlob.DownloadToStream(ms);
                string result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                return ms.ToArray();
            }
        }


        public void DeleteBlob()
        {
            try { 
            var _containerName = "containerone";
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=contosodemo;AccountKey=gApKbiLzjv6z8nQrEQpmHSKWJGSrGtbiu2QILPp+QWXGX83PpSxosipzKtjLoK5rf0pI0QGlXutLPlbJ0xFw6w==");
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=anotherregiondemo;AccountKey=Hl0UiGSqYadHcTMKkK/eYgFoC0hwn3pOAFxbreeInn5oN2yIfBdzfiYAhtZrXlZubvf1RP0V8l7KH9+lYL3omQ==");
                CloudBlobClient _blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer _cloudBlobContainer = _blobClient.GetContainerReference(_containerName);
            CloudBlockBlob _blockBlob = _cloudBlobContainer.GetBlockBlobReference("123.png");
            //delete blob from container    
            _blockBlob.DeleteIfExists();
            }
            catch (Exception e)
            {

            }
        }

        //public static async void DownloadFile()
        //{
        //    BlobWrapper _blobWrapper = new BlobWrapper();
        //    Task<byte[]> data = _blobWrapper.DownloadFileFromBlob("123.docx");
        //    byte[] d = await data;
        //}


        public static byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return imageData;
        }

    }

    internal class BlobUtilities
    {
        public static CloudBlobClient GetBlobClient
        {
            get
            {
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=contosodemo;AccountKey=gApKbiLzjv6z8nQrEQpmHSKWJGSrGtbiu2QILPp+QWXGX83PpSxosipzKtjLoK5rf0pI0QGlXutLPlbJ0xFw6w==");
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=anotherregiondemo;AccountKey=Hl0UiGSqYadHcTMKkK/eYgFoC0hwn3pOAFxbreeInn5oN2yIfBdzfiYAhtZrXlZubvf1RP0V8l7KH9+lYL3omQ==");
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                return blobClient;
            }
        }
    }
}
