class ProductDetailsPageController {
    datatable;
    tableData;

    constructor() {
        $(document).ready(() => this.init());
    }

    init(): void {
        this.initButtons();
    }
    initButtons() {
        $(document).on('click', '.btn-add-to-cart', function () {
            let productId = $(this).data("id");
            let formData = new FormData();
            formData.append("productId", productId);
            $.ajax({
                url: "/ShoppingCart/AddToCart",
                method: "POST",
                data: formData,
                processData: false,
                contentType: false,
                success: function (dataResponse) {
                    if (dataResponse.success) {
                        alert(dataResponse.message);
                        shoppingCartSharedPartialController.setCounterCart(dataResponse.counter);
                    }
                }
            });
        });
    }

}

let productDetailsPageController = new ProductDetailsPageController();
