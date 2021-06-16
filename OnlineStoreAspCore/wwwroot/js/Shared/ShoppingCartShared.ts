class ShoppingCartSharedPartialController {
    constructor() {
        $(document).ready(() => this.init());
    }

    init(): void {
    }

    setCounterCart(counter: number) {
        if (counter == 0) {
            $('#shoppingCartNav').text("Cart");
        }
        else {
            $('#shoppingCartNav').text("Cart("+counter+")")
        }
    }
}

let shoppingCartSharedPartialController = new ShoppingCartSharedPartialController();