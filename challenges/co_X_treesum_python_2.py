# AI generated reference implementation

def three_sum(numbers: list[int]) -> list[tuple[int, int, int]]:
    numbers = sorted(numbers) # c(threesum) = log(n)
    result: list[tuple[int, int, int]] = []

    for first in range(len(numbers) - 2): #c(threesum) = log(n log n)
        # Avoid repeating the same first value.
        if first > 0 and numbers[first] == numbers[first - 1]:
            continue

        left = first + 1
        right = len(numbers) - 1

        while left < right:
            total = numbers[first] + numbers[left] + numbers[right]

            if total < 0:
                left += 1
            elif total > 0:
                right -= 1
            else:
                result.append(
                    (numbers[first], numbers[left], numbers[right])
                )

                left += 1
                right -= 1

                # Avoid duplicate triplets.
                while left < right and numbers[left] == numbers[left - 1]:
                    left += 1

                while left < right and numbers[right] == numbers[right + 1]:
                    right -= 1

    return result
