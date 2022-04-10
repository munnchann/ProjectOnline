////var SiteController = function () {
////    this.initialize = function () {
////        loadCart();
////    }
////    function loadCart() {
////        $.ajax({
////            type: "GET",
////            url: "/" + '/Cart/GetListItems',
////            success: function (res) {
////                $('#CartCount').text(@Session["count"]);
////            }
////        });
////    }
//    function regsiterEvents() {
//        // Write your JavaScript code.
//        $('body').on('click', '.btn-add-cart', function (e) {
//            e.preventDefault();
//            const culture = $('#hidCulture').val();
//            const id = $(this).data('id');
//            $.ajax({
//                type: "POST",
//                url: "/" + culture + '/Cart/AddToCart',
//                data: {
//                    id: id,
//                    languageId: culture,
//                },
//                success: function (res) {

//                    $('#lbl_number_items_header').text(res.length);

//                },
//                error: function (err) {

//                    console.log(err);

//                }
//            });
//        });
//    }
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}