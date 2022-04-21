var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadCart();
        
    }
    function loadCart() {
        $.ajax({
            type: "GET",
            url: "/" + '/Cart/GetListItems',
            success: function (res) {
                $('#CartCount').text(res.length);
            }
        });
    }
    function regsiterEvents() {
        $(".btn-add-cart").click(function () {
            $.ajax({
                url: "/Cart/AddToCart",
                data: {
                    productId: $(this).data("id"),
                },
                success: function (data) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Thêm giỏ hàng thành công',
                        showConfirmButton: false,
                        timer: 2500
                    });
                    $('#CartCount').text(res.length);
                },
                error: function () {
                    Swal.fire({
                        icon: 'error',
                        title: 'Thêm giỏ hàng thất bại',
                        text: 'Vui lòng thử lại',
                        showConfirmButton: false,
                        timer: 2500
                    });
                }
            });
        });
    }
}