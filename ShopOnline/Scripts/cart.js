var CartController = function () {
    this.initialize = function () {
     
        registerEvents();
    }

    function registerEvents() {
        $('.btn-plus').off('click').on('click', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
            updateCart(id, quantity);
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

    function updateCart(id, quantity) {
        $.ajax({
            url: 'Cart/Update',
            type: 'POST',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $('#CartCount').text(res.lentgh);
                window.location.href = "/Cart";
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    //function loadData() {
    //    $.ajax({
    //        type: "GET",
    //        url: "/" + '/Cart/GetListItems',
    //        success: function (res) {
    //            if (res.length === 0) {
    //                $('#tbl_cart').hide();
    //            }
    //            var html = '';
    //            var total = 0;

    //            $.each(res, function (i, item) {
    //                var amount = item.price * item.quantity;
    //                html += "<tr>"
    //                    + "<td> <img width=\"60\" src=\"" + item.image + "\" alt=\"\" /></td>"
    //                    + "<td>" + item.detail + "</td>"
    //                    + "<td><div class=\"input-append\"><input class=\"span1\" style=\"max-width: 34px\" placeholder=\"1\" id=\"txt_quantity_" + item.productID + "\" value=\"" + item.quantity + "\" size=\"16\" type=\"text\">"
    //                    + "<button class=\"btn btn-minus\" data-id=\"" + item.productID + "\" type =\"button\"> <i class=\"icon-minus\"></i></button>"
    //                    + "<button class=\"btn btn-plus\" type=\"button\" data-id=\"" + item.productID + "\"><i class=\"icon-plus\"></i></button>"
    //                    + "<button class=\"btn btn-danger btn-remove\" type=\"button\" data-id=\"" + item.productID + "\"><i class=\"icon-remove icon-white\"></i></button>"
    //                    + "</div>"
    //                    + "</td>"

    //                    + "<td>" + numberWithCommas(item.price) + "</td>"
    //                    + "<td>" + numberWithCommas(amount) + "</td>"
    //                    + "</tr>";
    //                total += amount;
    //            });
    //            $('#cart_body').html(html);
    //            $('#CartCount').text(res.length);
    //            $('#lbl_total').text(numberWithCommas(total));
    //        }
    //    });
    //}
}