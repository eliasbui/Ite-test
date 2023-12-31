
# ITE TEST EXAMPLE



## Assignments

We are starting a computer store. You have been engaged to build the checkout system. We will start with the following products in our catalogue


| SKU     | Name        | Price    |
| --------|:-----------:| --------:|
| ipd     | Super iPad  | $549.99  |
| mbp     | MacBook Pro | $1399.99 |
| atv     | Apple TV    | $109.50  |
| vga     | VGA adapter | $30.00   |

As we're launching our new computer store, we would like to have a few opening day specials.

As we're launching our new computer store, we would like to have a few opening day specials.

- we're going to have a 3 for 2 deal on Apple TVs. For example, if you buy 3 Apple TVs, you will pay the price of 2 only
- the brand new Super iPad will have a bulk discounted applied, where the price will drop to $499.99 each, if someone buys more than 4
- we will bundle in a free VGA adapter free of charge with every MacBook Pro sold

As our Sales manager is quite indecisive, we want the pricing rules to be as flexible as possible as they can change in the future with little notice.

Our checkout system can scan items in any order.

The interface to our checkout looks like this (shown in .Net):

```.Net
  Checkout co = new Checkout(pricingRules);
  co.scan(item1);
  co.scan(item2);
  co.total();
```

Your task is to implement a checkout system that fulfils the requirements described above.

Example scenarios
-----------------

SKUs Scanned: atv, atv, atv, vga
Total expected: $249.00

SKUs Scanned: atv, ipd, ipd, atv, ipd, ipd, ipd
Total expected: $2718.95

SKUs Scanned: mbp, vga, ipd
Total expected: $1949.98

Notes on implementation:

- use **.Net or .Net Core**
- try not to spend more than 2 hours maximum. (We don't want you to lose a weekend over this!)
- don't build guis etc, we're more interested in your approach to solving the given task, not how shiny it looks
- don't worry about making a command line interface to the application
- don't use any external NuGet Packages (unless it's for testing or build/dependency injection)

#### Clone Project

```.Net
  git clone https://github.com/Dthai16gg/Ite-test.git && cd Ite-test
```

#### Run Project

```.Net
  dotnet run
```

## 🔗 Solution
[Click Here](https://github.com/Dthai16gg/Ite-test/wiki)
## Example scenarios
#### Scenarios 1:

```.Net
  SKUs Scanned: atv, atv, atv, vga
  Total expected: $249.00
```

https://github.com/Dthai16gg/Ite-test/assets/88380128/9e4b7776-e9d1-4ab4-bd93-f32c7e7ad1c1


#### Scenarios 2:

```.Net
  SKUs Scanned: atv, ipd, ipd, atv, ipd, ipd, ipd
  Total expected: $2718.95
```


https://github.com/Dthai16gg/Ite-test/assets/88380128/aa256a3a-a119-4c1e-a6dc-b1a245e654f1


#### Scenarios 3:
```.Net
  SKUs Scanned: mbp, vga, ipd
  Total expected: $1949.98
```

https://github.com/Dthai16gg/Ite-test/assets/88380128/c33c3dfd-2943-4ab1-9e9c-ebcc1aa7850e

