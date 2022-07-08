namespace ExtendSharp
{
    public partial class ExtendPurchaseOrdersClientSharp
    {
        private string _baseUrl = "https://developer.lxir.se/RESTAPI";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public ExtendPurchaseOrdersClientSharp(System.Net.Http.HttpClient httpClient)
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
        /// <summary>Get a list of purchase orders</summary>
        /// <param name="purchaseNumber">The purchase number</param>
        /// <param name="createDateFrom">Create date from</param>
        /// <param name="createDateTo">Create date to</param>
        /// <param name="warehouse">Warehouse</param>
        /// <param name="isOpen">Get only open purchases</param>
        /// <param name="isReceived">Get only purchases with something received</param>
        /// <param name="externalOrderNumber">Purchase number from external system</param>
        /// <param name="supplierNumber">Supplier number</param>
        /// <param name="supplierOrderNumber">Purchase number used by supplier</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PurchaseOrderListItemList> GetPurchaseOrderListAsync(string client, string purchaseNumber, System.DateTimeOffset? createDateFrom, System.DateTimeOffset? createDateTo, string warehouse, bool? isOpen, bool? isReceived, string externalOrderNumber, string supplierNumber, string supplierOrderNumber, int? pageNumber, string extendBasicAuthorization)
        {
            return GetPurchaseOrderListAsync(client, purchaseNumber, createDateFrom, createDateTo, warehouse, isOpen, isReceived, externalOrderNumber, supplierNumber, supplierOrderNumber, pageNumber, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of purchase orders</summary>
        /// <param name="purchaseNumber">The purchase number</param>
        /// <param name="createDateFrom">Create date from</param>
        /// <param name="createDateTo">Create date to</param>
        /// <param name="warehouse">Warehouse</param>
        /// <param name="isOpen">Get only open purchases</param>
        /// <param name="isReceived">Get only purchases with something received</param>
        /// <param name="externalOrderNumber">Purchase number from external system</param>
        /// <param name="supplierNumber">Supplier number</param>
        /// <param name="supplierOrderNumber">Purchase number used by supplier</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PurchaseOrderListItemList> GetPurchaseOrderListAsync(string client, string purchaseNumber, System.DateTimeOffset? createDateFrom, System.DateTimeOffset? createDateTo, string warehouse, bool? isOpen, bool? isReceived, string externalOrderNumber, string supplierNumber, string supplierOrderNumber, int? pageNumber, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/PurchaseOrders?");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            if (purchaseNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("purchaseNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(purchaseNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (createDateFrom != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("createDateFrom") + "=").Append(System.Uri.EscapeDataString(createDateFrom.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (createDateTo != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("createDateTo") + "=").Append(System.Uri.EscapeDataString(createDateTo.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (warehouse != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("warehouse") + "=").Append(System.Uri.EscapeDataString(ConvertToString(warehouse, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (isOpen != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("IsOpen") + "=").Append(System.Uri.EscapeDataString(ConvertToString(isOpen, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (isReceived != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("IsReceived") + "=").Append(System.Uri.EscapeDataString(ConvertToString(isReceived, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (externalOrderNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("externalOrderNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(externalOrderNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (supplierNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("supplierNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(supplierNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (supplierOrderNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("supplierOrderNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(supplierOrderNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
                            var objectResponse_ = await ReadObjectResponseAsync<PurchaseOrderListItemList>(response_, headers_, cancellationToken).ConfigureAwait(false);
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

        /// <summary>Get a single purchase order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The purchase order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<PurchaseOrder> GetPurchaseOrderAsync(string client, string id, string extendBasicAuthorization)
        {
            return GetPurchaseOrderAsync(client, id, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a single purchase order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The purchase order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<PurchaseOrder> GetPurchaseOrderAsync(string client, string id, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/PurchaseOrders/{id}");
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
                            var objectResponse_ = await ReadObjectResponseAsync<PurchaseOrder>(response_, headers_, cancellationToken).ConfigureAwait(false);
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
            if (response == null || response.Content == null)
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
            return result == null ? "" : result;
        }
    }
}
