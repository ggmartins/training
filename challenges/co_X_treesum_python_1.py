a1 = [1, 2, 20, 12, -3, -4]

cache = {}

res = {}

def testf(a):
   for n1, i in enumerate(a):
      for n2, j in enumerate(a[n1+1:]):
         cache[i + j] = sorted([i, j])

   for n3, k in enumerate(a):
      if (c:=cache.get(-k, None)) is not None:
        if k in c: continue
        c.append(k)
        res[tuple(sorted(c))] = 1

testf(a1)

print(res)
