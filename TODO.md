# TODO

## Leetcode
- [ ] 3908. Valid Digit Number
```csharp
        int mod = 1;

        bool found = false;

        while( n >= mod ){
            mod *= 10;
            
            int remainder = n % mod;
            n /= mod;

            if(remainder == x){
                found = true;
            }
        }

        return found && n != x;
```

## Easy

- [x] Prevent duplicate book titles
- [x] Add a menu option to delete a book
- [ ] ~~Add a menu option to list only available books~~ -=> REMOVED BECAUSE TOO EASY
- [ ] ~~Add a menu option to list only checked-out books~~ -=> REMOVED BECAUSE TOO EASY

### Medium

- [x] Add a `Magazine` class -=> REDUCED SCOPE DUE TO DUPLICATING KNOWN CONCEPTS
- [ ] ~~Add a `DVD` class~~ -=> REMOVED BECAUSE SAME AS PREVIOUS
- [ ] Make `Library` store `List<LibraryItem>` instead of `List<Book>`
- [ ] Use polymorphism to call `DisplayInfo` on different item types

### Harder

- [ ] Save books to a file
- [ ] Load books from a file when the app starts
- [ ] Add unit tests
- [ ] Convert the console app into an ASP.NET Core Web API