# Sample project of file signature generator

## Description
Program in the project splits input file into blocks of equal size, calculates SHA256 hash for every block and writes hash with block's number to standard output in order of numbers

## Input
Two arguments in command line:
- path to file
- size of block

## Output
Lines of signature in format:

`number - SHA256`

## Example:
Input: [data.txt](https://github.com/gologames/Signature-Generator/blob/main/Signature%20Generator/Signature%20Generator/Data/data.txt) 2

Output:

```
0 - AA58B21B01D6B8A99C1A5856962DBAC36C758A79DC0A77C2E013CE2C39ECDC8A
1 - 76592B9DE6D38238A52A3651867871E5C670E6320A8EF46A84B5590F8933F33E
```

## Data

You can generate data with [generate_data.py](https://github.com/gologames/Signature-Generator/blob/main/Signature%20Generator/Signature%20Generator/Data/generate_data.py) script. Pass file name and count of data parts to this script as command line arguments to generate file with sample data
