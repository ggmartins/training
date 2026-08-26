a1 = [1, 2, 20, 12, -3, -4]

def testf(a):
   cache = {}
   res = {}
   for n1, i in enumerate(a):
      for n2 in range(n1 +1, len(a)):
         j = a[n2]
         cache[i + j] = sorted([i, j])

   for n3, k in enumerate(a):
      if (c:=cache.get(-k, None)) is not None:
        if k in c: continue
        r = c + [k]
        res[tuple(sorted(r))] = 1

   return res


res = testf(a1)

print(res)
