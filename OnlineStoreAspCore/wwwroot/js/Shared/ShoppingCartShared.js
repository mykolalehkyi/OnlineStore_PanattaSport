class ShoppingCartSharedPartialController {
    constructor() {
        $(document).ready(() => this.init());
    }
    init() {
    }
    setCounterCart(counter) {
        if (counter == 0) {
            $('#shoppingCartNav').text("Cart");
        }
        else {
            $('#shoppingCartNav').text("Cart(" + counter + ")");
        }
    }
}
let shoppingCartSharedPartialController = new ShoppingCartSharedPartialController();
//# sourceMappingURL=ShoppingCartShared.js.map