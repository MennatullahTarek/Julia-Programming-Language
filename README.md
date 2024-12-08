# Julia Programming Language - Grammar

## Overview

This project contains the formal grammar for the **Julia programming language**, focusing on the syntax rules for different types of statements, expressions, conditionals, loops, and method declarations. The grammar follows a production rule format, making it easy to understand how Julia code is structured.

## Author

- **Author**: Mennatullah Tarek

## About

The Julia language grammar defines how Julia programs are structured, including key constructs like:

- Assignment statements
- Conditional statements (`if`, `else`, `elseif`)
- Loops (`for`, `while`)
- Method declarations and calls

This repository is a useful resource for anyone learning Julia or interested in understanding the underlying syntax structure of the language.

## Grammar Overview

The grammar is divided into several components:

### 1. Terminal Symbols
- **Id**: Represents an identifier (variable name).
- **Digit**: Represents a numeric digit.

### 2. Non-terminal Symbols
- **Program**: The root symbol representing the structure of a complete program.
- **Statement List**: A sequence of statements.
- **Concepts**: Various types of statements, such as assignments, conditionals, loops, and method calls.

### 3. Core Grammar Rules

- **Program Structure**:  
  A basic Julia program starts with the `Start` keyword and ends with the `End` keyword:
  ```text
  <program> ::= Start <statement_list> End
