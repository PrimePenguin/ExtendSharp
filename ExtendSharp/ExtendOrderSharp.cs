namespace ExtendSharp
{
    public partial class ExtendOrderSharp
    {
        private string _baseUrl = "https://developer.lxir.se/RESTAPI";
        private System.Net.Http.HttpClient _httpClient;
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public ExtendOrderSharp(System.Net.Http.HttpClient httpClient)
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

        /// <summary>Gets a list of orders</summary>
        /// <param name="client">The client</param>
        /// <param name="orderNumber">The order number</param>
        /// <param name="orderNumberExternal">The order number specified by external system.</param>
        /// <param name="shippingNumber">Shipping number for warehouse orders. Shipping numbers for direct delivery orders are not searchable.</param>
        /// <param name="modifiedDateFrom">Order must have been modified after this date. Use fully qualified utc format.</param>
        /// <param name="pageCount">The size of page, default is 100.</param>
        /// <param name="pageOffset">The page number, default is 0 and returns the first page.</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<CustomerOrderListItem>> GetAllOrdersAsync(string client, string orderNumber, string orderNumberExternal, OrderStatus? orderStatus, SupplyMode? supplyMode, System.DateTimeOffset? orderDateFrom, System.DateTimeOffset? orderDateTo, System.DateTimeOffset? askedDeliveryDate, System.DateTimeOffset? endDate, string customerNumber, string customerName, string deliveryCountryCode, string companyGroup, string productNumber, string productName, string invoiceNumber, string warehouse, string shippingNumber, System.DateTimeOffset? modifiedDateFrom, int? pageCount, int? pageOffset, string extendBasicAuthorization)
        {
            return GetAllOrdersAsync(client, orderNumber, orderNumberExternal, orderStatus, supplyMode, orderDateFrom, orderDateTo, askedDeliveryDate, endDate, customerNumber, customerName, deliveryCountryCode, companyGroup, productNumber, productName, invoiceNumber, warehouse, shippingNumber, modifiedDateFrom, pageCount, pageOffset, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Gets a list of orders</summary>
        /// <param name="client">The client</param>
        /// <param name="orderNumber">The order number</param>
        /// <param name="orderNumberExternal">The order number specified by external system.</param>
        /// <param name="shippingNumber">Shipping number for warehouse orders. Shipping numbers for direct delivery orders are not searchable.</param>
        /// <param name="modifiedDateFrom">Order must have been modified after this date. Use fully qualified utc format.</param>
        /// <param name="pageCount">The size of page, default is 100.</param>
        /// <param name="pageOffset">The page number, default is 0 and returns the first page.</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<CustomerOrderListItem>> GetAllOrdersAsync(string client, string orderNumber, string orderNumberExternal, OrderStatus? orderStatus, SupplyMode? supplyMode, System.DateTimeOffset? orderDateFrom, System.DateTimeOffset? orderDateTo, System.DateTimeOffset? askedDeliveryDate, System.DateTimeOffset? endDate, string customerNumber, string customerName, string deliveryCountryCode, string companyGroup, string productNumber, string productName, string invoiceNumber, string warehouse, string shippingNumber, System.DateTimeOffset? modifiedDateFrom, int? pageCount, int? pageOffset, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/CustomerOrders?");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            if (orderNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("orderNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(orderNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (orderNumberExternal != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("orderNumberExternal") + "=").Append(System.Uri.EscapeDataString(ConvertToString(orderNumberExternal, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (orderStatus != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("orderStatus") + "=").Append(System.Uri.EscapeDataString(ConvertToString(orderStatus, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (supplyMode != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("supplyMode") + "=").Append(System.Uri.EscapeDataString(ConvertToString(supplyMode, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (orderDateFrom != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("orderDateFrom") + "=").Append(System.Uri.EscapeDataString(orderDateFrom.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (orderDateTo != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("orderDateTo") + "=").Append(System.Uri.EscapeDataString(orderDateTo.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (askedDeliveryDate != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("askedDeliveryDate") + "=").Append(System.Uri.EscapeDataString(askedDeliveryDate.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (endDate != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("endDate") + "=").Append(System.Uri.EscapeDataString(endDate.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (customerNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("customerNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(customerNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (customerName != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("customerName") + "=").Append(System.Uri.EscapeDataString(ConvertToString(customerName, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (deliveryCountryCode != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("deliveryCountryCode") + "=").Append(System.Uri.EscapeDataString(ConvertToString(deliveryCountryCode, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (companyGroup != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("companyGroup") + "=").Append(System.Uri.EscapeDataString(ConvertToString(companyGroup, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (productNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("productNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(productNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (productName != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("productName") + "=").Append(System.Uri.EscapeDataString(ConvertToString(productName, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (invoiceNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("invoiceNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(invoiceNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (warehouse != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("warehouse") + "=").Append(System.Uri.EscapeDataString(ConvertToString(warehouse, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (shippingNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("shippingNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(shippingNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (modifiedDateFrom != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("modifiedDateFrom") + "=").Append(System.Uri.EscapeDataString(modifiedDateFrom.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
                            var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<CustomerOrderListItem>>(response_, headers_, cancellationToken).ConfigureAwait(false);
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

        /// <summary>Create a new order</summary>
        /// <param name="client">The client</param>
        /// <param name="newCustomerOrder">The new customer order</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CustomerOrder> PostNewOrderAsync(string client, CustomerOrder newCustomerOrder, string extendBasicAuthorization)
        {
            return PostNewOrderAsync(client, newCustomerOrder, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Create a new order</summary>
        /// <param name="client">The client</param>
        /// <param name="newCustomerOrder">The new customer order</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CustomerOrder> PostNewOrderAsync(string client, CustomerOrder newCustomerOrder, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (newCustomerOrder == null)
                throw new System.ArgumentNullException("newCustomerOrder");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/CustomerOrders");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    if (extendBasicAuthorization != null)
                        request_.Headers.TryAddWithoutValidation("ExtendBasicAuthorization", ConvertToString(extendBasicAuthorization, System.Globalization.CultureInfo.InvariantCulture));
                    // var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(newCustomerOrder, _settings.Value);
                    // var dictionary_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, string>>(json_, _settings.Value);
                    // var content_ = new System.Net.Http.FormUrlEncodedContent(dictionary_);
                    // content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    // request_.Content = content_;

                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(newCustomerOrder, _settings.Value));
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
                            var objectResponse_ = await ReadObjectResponseAsync<CustomerOrder>(response_, headers_, cancellationToken).ConfigureAwait(false);
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

        /// <summary>Get a single order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CustomerOrder> GetOrderAsync(string client, string id, string extendBasicAuthorization)
        {
            return GetOrderAsync(client, id, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a single order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CustomerOrder> GetOrderAsync(string client, string id, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/CustomerOrders/{id}");
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
                            var objectResponse_ = await ReadObjectResponseAsync<CustomerOrder>(response_, headers_, cancellationToken).ConfigureAwait(false);
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

        /// <summary>Update an order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The order number</param>
        /// <param name="existingCustomerOrder">The existing customer order</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CustomSuccess> PutExistingOrderAsync(string client, string id, CustomerOrder existingCustomerOrder, string extendBasicAuthorization)
        {
            return PutExistingOrderAsync(client, id, existingCustomerOrder, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Update an order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The order number</param>
        /// <param name="existingCustomerOrder">The existing customer order</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CustomSuccess> PutExistingOrderAsync(string client, string id, CustomerOrder existingCustomerOrder, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            if (existingCustomerOrder == null)
                throw new System.ArgumentNullException("existingCustomerOrder");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/CustomerOrders/{id}");
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
                    // var json_ = Newtonsoft.Json.JsonConvert.SerializeObject(existingCustomerOrder, _settings.Value);
                    // var dictionary_ = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, string>>(json_, _settings.Value);
                    // var content_ = new System.Net.Http.FormUrlEncodedContent(dictionary_);
                    // content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    // request_.Content = content_;
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(existingCustomerOrder, _settings.Value));
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

        /// <summary>Get a list of return orders</summary>
        /// <param name="returnNumber">The return number</param>
        /// <param name="createDateFrom">Create date from</param>
        /// <param name="createDateTo">Create date to</param>
        /// <param name="referenceOrderNumber">Reference order number</param>
        /// <param name="warehouse">Warehouse</param>
        /// <param name="customerNumber">Customer number</param>
        /// <param name="isOpen">Get only open returns</param>
        /// <param name="isReceived">Get only returns with something received</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ReturnOrderListItemList> GetReturnOrderListAsync(string client, string returnNumber, System.DateTimeOffset? createDateFrom, System.DateTimeOffset? createDateTo, string referenceOrderNumber, string warehouse, string customerNumber, bool? isOpen, bool? isReceived, int? pageNumber, string extendBasicAuthorization)
        {
            return GetReturnOrderListAsync(client, returnNumber, createDateFrom, createDateTo, referenceOrderNumber, warehouse, customerNumber, isOpen, isReceived, pageNumber, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a list of return orders</summary>
        /// <param name="returnNumber">The return number</param>
        /// <param name="createDateFrom">Create date from</param>
        /// <param name="createDateTo">Create date to</param>
        /// <param name="referenceOrderNumber">Reference order number</param>
        /// <param name="warehouse">Warehouse</param>
        /// <param name="customerNumber">Customer number</param>
        /// <param name="isOpen">Get only open returns</param>
        /// <param name="isReceived">Get only returns with something received</param>
        /// <param name="pageNumber">The number of the page. First page is 1. Default is 1</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ReturnOrderListItemList> GetReturnOrderListAsync(string client, string returnNumber, System.DateTimeOffset? createDateFrom, System.DateTimeOffset? createDateTo, string referenceOrderNumber, string warehouse, string customerNumber, bool? isOpen, bool? isReceived, int? pageNumber, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/ReturnOrders?");
            urlBuilder_.Replace("{client}", System.Uri.EscapeDataString(ConvertToString(client, System.Globalization.CultureInfo.InvariantCulture)));
            if (returnNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("returnNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(returnNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (createDateFrom != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("createDateFrom") + "=").Append(System.Uri.EscapeDataString(createDateFrom.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (createDateTo != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("createDateTo") + "=").Append(System.Uri.EscapeDataString(createDateTo.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (referenceOrderNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("referenceOrderNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(referenceOrderNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (warehouse != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("warehouse") + "=").Append(System.Uri.EscapeDataString(ConvertToString(warehouse, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (customerNumber != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("customerNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(customerNumber, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (isOpen != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("IsOpen") + "=").Append(System.Uri.EscapeDataString(ConvertToString(isOpen, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (isReceived != null)
            {
                urlBuilder_.Append(System.Uri.EscapeDataString("IsReceived") + "=").Append(System.Uri.EscapeDataString(ConvertToString(isReceived, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
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
                            var objectResponse_ = await ReadObjectResponseAsync<ReturnOrderListItemList>(response_, headers_, cancellationToken).ConfigureAwait(false);
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

        /// <summary>Get a single return order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The return order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ReturnOrder> GetReturnOrderAsync(string client, string id, string extendBasicAuthorization)
        {
            return GetReturnOrderAsync(client, id, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Get a single return order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The return order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ReturnOrder> GetReturnOrderAsync(string client, string id, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/ReturnOrders/{id}");
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
                            var objectResponse_ = await ReadObjectResponseAsync<ReturnOrder>(response_, headers_, cancellationToken).ConfigureAwait(false);
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

        /// <summary>Delete an order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<CustomSuccess> DeleteOrderAsync(string client, string id, string extendBasicAuthorization)
        {
            return DeleteOrderAsync(client, id, extendBasicAuthorization, System.Threading.CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>Delete an order</summary>
        /// <param name="client">The client</param>
        /// <param name="id">The order number</param>
        /// <param name="extendBasicAuthorization">Header containing basic auth information</param>
        /// <exception cref="ExtendSharpApiException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<CustomSuccess> DeleteOrderAsync(string client, string id, string extendBasicAuthorization, System.Threading.CancellationToken cancellationToken)
        {
            if (client == null)
                throw new System.ArgumentNullException("client");

            if (id == null)
                throw new System.ArgumentNullException("id");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1_0/{client}/CustomerOrders/{id}");
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
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default, string.Empty);
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
