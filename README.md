# Digital Library Vertical Prototype

### Contributors

- ABHINAV GHAI, abhinav.ghai@ucalgary.ca
- ALY KHEDR, aly.khedr@ucalgary.ca
- DANIEL JIN, daniel.jin@ucalgary.ca
- DOOWEN CHO, doowen.cho@ucalgary.ca
- TYLER HARTLEB, tyler.hartleb1@ucalgary.ca

## About the Project

This project is a vertical prototype implemented using Windows Presentation Foundation developed using a task-centered design approach. The primary purpose of this prototype is to provide information about a Library’s digital and physical offerings. For example, the mobile app provides information about a book; for physical books, this may include the physical location; for digital books, the availability.

### Built With

- WPF
- C#

## Getting Started

### Prerequisites

- Visual Studio 2022

### Installation

1. Clone the repo
  ```
  git clone https://github.com/tylerHartleb/Digital-Library-Prototype.git
  ```
2. Open the repo in Visual Studio 2022
3. Build the project

## Usage

### How to run

1. Build the project
2. Start the app with the `f5` key or by going to **Debug > Start Debugging**

### Features

#### Accounts
Supports logging in for 4 user accounts
  ```
  User John Doe = {id: 12345678910111, password: "password"}
  User Jane Doe = {id: 10020050060099, password: "ILoveUoC"}
  User Peter Johnson = {id: 30051478900000, password: "password1"}
  User Alice Blue = {id: 10000000000000, "password"}
  ```

#### Example Data
There are a number of example books with filled in data available to interact with. Each book is put into one or more of the example categories Adventure, Fantasy, Mystery,
 Motivation, History, and Cookbook. Additionaly, each book has an author associated with it. Finally, there are two example series "Percy Jackson & the Olympians" and "A Song of Ice and Fire".
 There are four library locations defined Nose Hill, Downtown, Fish Creek, and Bowness, each of these locations have information for the available books and held books.
 
 #### Search
 
 The initial search page displays 3 discover tags, and a list of recommended Fantasy books. You can click each discover tag to be brought to a search for the tag. The search input uses a sliding window Levenshtein distance algorithm
 to determine search results, this supports searching over book titles, book series, categories, and author names. The algorithm using the search term searches for the closest matching substring, for example if you want to find books written by
 Jules Verne, you can type in "verne" and the top results will be books written by Jules Verne or if you want to find books from the series Percy Jackson & the Olympians, you can search for "percy jackson" or "olympians" to get results.
 
 #### Book info
 Once you have selected a book, you are shown the "Book Details" page, this displays the book title, it's formats, a synopsis. Additionally, it will display books written by the same author, related books, and books in the same series (each fully interactable).
 From here you can select a format and (if you're signed in) can check out or place a hold depending on the format and the availability. The book will be added to the account section under either checked out books, or held books*. 
 
 *Note checked out / held books are not persisted through application resets and are not deducted from the total from the library location.
 
 #### Example walkthrough
 
 Alice is a fan of Game of Thrones, she just finished reading "A Feast of Crows" and wants to place a hold on a physical copy of "The Winds of Winter" from the Bowness location as the book just came out and is a popular item.
 
 1. Alice opens the app
 2. She logs in using her credentials {id: 10000000000000, "password"}
 3. Upon logging in she notices one of her books is overdue
 4. She selects the search tab
 5. She enters the search term "song of ice and fire"
 6. She scrolls down and selects the book "The Winds of Winter"
 7. She selects a physical copy
 8. She selects place hold
 9. She confirms that the hold is at her preferred location and places the hold
 10. She navigates to her account
 11. She selects Held items
 12. She takes a note of the date she needs to pick up the book.




