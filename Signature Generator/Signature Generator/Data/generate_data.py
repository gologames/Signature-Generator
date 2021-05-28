import sys

DATA_STRING = 'data'

def main():
	if (len(sys.argv) != 3):
		print('Incorrect count of command line arguments', file=sys.stderr)
		exit(1)
	path = sys.argv[1]
	count = int(sys.argv[2])
	with open(path, 'w') as f:
		while count > 0:
			f.write(DATA_STRING)
			count -= 1

if __name__ == "__main__":
	main()