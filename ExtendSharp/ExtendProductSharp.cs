namespace ExtendSharp
{
    public partial class ExtendProductSharp
    {
        private string _baseUrl = "https://developer.lxir.se/RESTAPI";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public ExtendProductSharp(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

        private Newtonsoft.Json.JsonSerializerSettings CreateSerializerSettings()
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        }

        public string BaseUrl
        {
            get => _baseUrl;
            set => _baseUrl = value;
        }
        protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings => _settings.Value;

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);


        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);
        /// <summary>Get a list of products</summary>
        /// <param name="client">The client</param>
        /// <param name="productNumber">The product number</param>
        /// <param name="productName">The name of the product</param>
        /// <param name="supplyMode">The supply mode</param>
        /// <param name="modifiedDateFrom">Product must have been modified after this date. Use fully qualified utc format.</param>
        /// <param name="modifiedDateTo">Product must have been modified before this date</param>
        /// <param name="warehouse">Shortname of warehouse</param>
        /// <param name="pageCount">The size of page, default is 100</param>
        /// <param name="pageOffset">The page number, default is 0 and returns the first page</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ProductListItem>> GetAllProductsAsync(string client, string productNumber, string productName, SupplyMode2? supplyMode, string supplierNumber, string supplierProductNumber, System.DateTimeOffset? modifiedDateFrom, System.DateTimeOffset? modifiedDateTo, string warehouse, int? pageCount, int? pageOffset, string extendBasicAuthorization)
        {
            return GetAllProductsAsync(client, productNumber, productName, supplyMode, supplierNumber, supplierProductNumber, modifiedDateFrom, modifiedDateTo, warehouse, pageCount, pageOffset, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of products</summary>
        /// <param name="client">The client</param>
        /// <param name="productNumber">The product number</param>
        /// <param name="productName">The name of the product</param>
        /// <param name="supplyMode">The supply mode</param>
        /// <param name="modifiedDateFrom">Product must have been modified after this date. Use fully qualified utc format.</param>
        /// <param name="modifiedDateTo">Product must have been modified before this date</param>
        /// <param name="warehouse">Shortname of warehouse</param>
        /// <param name="pageCount">The size of page, default is 100</param>
        /// <param name="pageOffset">The page number, default is 0 and returns the first page</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ProductListItem>> GetAllProductsAsync(string client, string productNumber, string productName, SupplyMode2? supplyMode, string supplierNumber, string supplierProductNumber, System.DateTimeOffset? modifiedDateFrom, System.DateTimeOffset? modifiedDateTo, string warehouse, int? pageCount, int? pageOffset, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/Products?");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            if (productNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("productNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(productNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (productName != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("productName") + "=").Append(System.Uri.EscapeDataString(ConvertToString(productName, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (supplyMode != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("supplyMode") + "=").Append(System.Uri.EscapeDataString(ConvertToString(supplyMode, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (supplierNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("supplierNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(supplierNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (supplierProductNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("supplierProductNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(supplierProductNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (modifiedDateFrom != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("modifiedDateFrom") + "=").Append(System.Uri.EscapeDataString(modifiedDateFrom.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (modifiedDateTo != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("modifiedDateTo") + "=").Append(System.Uri.EscapeDataString(modifiedDateTo.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (warehouse != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("warehouse") + "=").Append(System.Uri.EscapeDataString(ConvertToString(warehouse, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (pageCount != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("pageCount") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageCount, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (pageOffset != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("pageOffset") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageOffset, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<ProductListItem>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ExtendSharpApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("BadRequest", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("Too many requests. (Rate limit = Standard)", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Create a new product</summary>
        /// <param name="client">The client</param>
        /// <param name="newProduct">The new product</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CustomSuccess> PostNewProductAsync(string client, Product newProduct, string extendBasicAuthorization)
        {
            return PostNewProductAsync(client, newProduct, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create a new product</summary>
        /// <param name="client">The client</param>
        /// <param name="newProduct">The new product</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CustomSuccess> PostNewProductAsync(string client, Product newProduct, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (newProduct == null)
                throw new System.ArgumentNullException("newProduct");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/Products");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    // var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(newProduct, _settings.Value);
                    // var dictionary_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, string>>(json_, _settings.Value);
                    // var content_ = new System.Net.Http.FormUrlEncodedContent(dictionary_);
                    // content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    // request_.Content = content_;

                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(newProduct, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<CustomSuccess>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ExtendSharpApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("BadRequest", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("Too many requests. (Rate limit = Standard)", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a list with balances for a specific warehouse.</summary>
        /// <param name="warehouse">The warehouse</param>
        /// <param name="productNumber">The product number</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<StockLevelList> GetWarehouseStocklevelsAsync(string client, string warehouse, string productNumber, int? pageNumber, string extendBasicAuthorization)
        {
            return GetWarehouseStocklevelsAsync(client, warehouse, productNumber, pageNumber, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list with balances for a specific warehouse.</summary>
        /// <param name="warehouse">The warehouse</param>
        /// <param name="productNumber">The product number</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<StockLevelList> GetWarehouseStocklevelsAsync(string client, string warehouse, string productNumber, int? pageNumber, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (warehouse == null)
                throw new System.ArgumentNullException("warehouse");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/WarehouseStockLevels?");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Append(System.Uri.EscapeDataString("warehouse") + "=").Append(System.Uri.EscapeDataString(ConvertToString(warehouse, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            if (productNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("productNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(productNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (pageNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("pageNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<StockLevelList>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ExtendSharpApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            var responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("BadRequest", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("Too many requests. (Rate limit = Standard)", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a  product availability.</summary>
        /// <param name="warehouse">The Warehouse</param>
        /// <param name="productNumber">Product Number</param>
        /// <param name="modifiedDateFrom">Availability must have been modified after this date. Use fully qualified utc format.</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ProductAvailabilityList> GetProductAvailabilityAsync(string client, string warehouse, string productNumber, System.DateTimeOffset? modifiedDateFrom, int? pageNumber, string extendBasicAuthorization)
        {
            return GetProductAvailabilityAsync(client, warehouse, productNumber, modifiedDateFrom, pageNumber, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a  product availability.</summary>
        /// <param name="warehouse">The Warehouse</param>
        /// <param name="productNumber">Product Number</param>
        /// <param name="modifiedDateFrom">Availability must have been modified after this date. Use fully qualified utc format.</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ProductAvailabilityList> GetProductAvailabilityAsync(string client, string warehouse, string productNumber, System.DateTimeOffset? modifiedDateFrom, int? pageNumber, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/ProductAvailability?");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            if (warehouse != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("warehouse") + "=").Append(System.Uri.EscapeDataString(ConvertToString(warehouse, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (productNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("productNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(productNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (modifiedDateFrom != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("modifiedDateFrom") + "=").Append(System.Uri.EscapeDataString(modifiedDateFrom.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (pageNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("pageNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(pageNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<ProductAvailabilityList>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ExtendSharpApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("BadRequest", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("Too many requests. (Rate limit = Standard)", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Get a single product.</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The productNumber</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<Product> GetProductAsync(string client, string id, string extendBasicAuthorization)
        {
            return GetProductAsync(client, id, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a single product.</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The productNumber</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<Product> GetProductAsync(string client, string id, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/Products/{id}");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<Product>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ExtendSharpApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("BadRequest", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 404)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("NotFound", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("Too many requests. (Rate limit = Standard)", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Update a product</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The product number</param>
        /// <param name="existingProduct">The existing product</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CustomSuccess> PutExistingProductAsync(string client, string id, Product existingProduct, string extendBasicAuthorization)
        {
            return PutExistingProductAsync(client, id, existingProduct, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Update a product</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The product number</param>
        /// <param name="existingProduct">The existing product</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CustomSuccess> PutExistingProductAsync(string client, string id, Product existingProduct, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            if (existingProduct == null)
                throw new System.ArgumentNullException("existingProduct");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/Products/{id}");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    // var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(existingProduct, _settings.Value);
                    // var dictionary_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, string>>(json_, _settings.Value);
                    // var content_ = new System.Net.Http.FormUrlEncodedContent(dictionary_);
                    // content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    // request_.Content = content_;

                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(existingProduct, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<CustomSuccess>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ExtendSharpApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("BadRequest", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("Too many requests. (Rate limit = Standard)", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        /// <summary>Delete a product</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The product number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CustomSuccess> DeleteProductAsync(string client, string id, string extendBasicAuthorization)
        {
            return DeleteProductAsync(client, id, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete a product</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The product number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CustomSuccess> DeleteProductAsync(string client, string id, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/Products/{id}");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{id}", System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<CustomSuccess>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ExtendSharpApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ == 400)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("BadRequest", status_, responseText_, headers_, null);
                        }
                        else
                        if (status_ == 429)
                        {
                            string responseText_ = (response_.Content == null) ? string.Empty : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("Too many requests. (Rate limit = Standard)", status_, responseText_, headers_, null);
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ExtendSharpApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Threading.CancellationToken cancellationToken)
        {
            if (response?.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ExtendSharpApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new System.IO.StreamReader(responseStream))
                    using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                    {
                        var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (Newtonsoft.Json.JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ExtendSharpApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is System.Enum)
            {
                var name = System.Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                            as System.Runtime.Serialization.EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = System.Convert.ToString(System.Convert.ChangeType(value, System.Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool)
            {
                return System.Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = System.Linq.Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = System.Convert.ToString(value, cultureInfo);
            return result ?? "";
        }
    }
}
