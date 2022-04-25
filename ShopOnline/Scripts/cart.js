var CartController = function () {
    this.initialize = function () {

        registerEvents();
      
       /* loadData();*/
    }

    function registerEvents() {
        $('.btn-plus').off('click').on('click', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
            //const price = $('#price_product').val();
            //const total = price * quantity;
            //$('#pricetotal_' + id).html(total);
            updateCart(id, quantity);
            //

        });

        $('.btn-minus').off('click').on('click', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) - 1;

            updateCart(id, quantity);
        });
        $('.btn-remove').off('click').on('click', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            updateCart(id, 0);
        });
    }
    function loadData() {
        $.ajax({
            url: '/Cart/CartBag',
            success: function (res) {
                $('#CartCount').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
   
    function updateCart(id, quantity) {      
        $.ajax({
            url: 'Cart/Update',
            type: 'POST',
            data: {
                id: id,
                quantity: quantity,
            },
            success: function () {
                window.location.reload(false);

                loadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    //function loadData() {
    //    $.ajax({
    //        type: "GET",
    //        url: '/Cart/Index',
    //        success: function (res) {
    //            if (res.length === 0) {
    //                $('#tbl_cart').hide();
    //            }
    //            var html = '';
    //            var total = 0;

    //            $.each(res, function (i, item) {
    //                var amounts = item.product.ProductID * item.quantity;
    //                html += "<tr id=\"product-" + item.productID + "\"/>"
    //                    + "<td class=\"product-thumbnail\">"
    //                    + "<img src=\"\" alt=\"\" class=\"img-fluid\">"
    //                    + "</td>"
    //                    + "<td class=\"product-name\">"
    //                    + "<h2 class=\"h5 text-black" > + item.product.ProductID + "\"</h2>"
    //                    + "</td>"
    //                + "<td>" + item.product.Price + "</td>"
    //                    + "<td>"
    //                    + "<div class=\"input-group mb-3\" style=\"max-width: 120px;\">"
    //                    + "<div class=\"input-group-prepend\">"
    //                + "<button class=\"btn btn-minus\" data-id=\"" + item.product.ProductID + "\" type=\"button\">&minus;</button>"
    //                + "</div>"
    //                + "<input type=\"button\" class=\"form-control text-center\" value=\"" + item.Quantity + "\" id=\"txt_quantity_" + item.product.ProductID + "\"  placeholder=\"1\"  aria-label=\"Example text with button addon\" aria-describedby=\"button-addon1\">"
    //                + "<div class=\"input-group-append\">"
    //                + "<button class=\"btn btn-plus\" data-id=\"" + item.product.ProductID + "\"  type=\"button\">&plus;</button>"
    //                    + "</div>"
    //                    + "</div>"
    //                    + "</td>"
    //                    + "<td>"+ item.product.Price + "</td>"
    //                + "<td>"+ amounts + "</td>"
    //                + "<td><a href=\"#\" class=\"btn btn-primary btn-remove\" data-id=\"" + item.product.ProductID + "\">X</a></td>"
    //                    + "</tr>";
    //                total += amounts;
    //            });
    //            $('#cart_body').html(html);
    //            $('#lbl_total').text(total);
    //        }
    //    });
    //}
}