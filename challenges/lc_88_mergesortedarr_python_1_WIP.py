class Solution:
    def merge(self, nums1: List[int], m: int, nums2: List[int], n: int) -> None:
        """
        :type nums1: List[int]
        :type m: int
        :type nums2: List[int]
        :type n: int
        :rtype: None Do not return anything, modify nums1 in-place instead.
        """

        if m == 0 and n == 0:
            return None
        if m == 0 and n > 0:
            for i in range(len(nums1)):
                nums1[i] = nums2[i]
            return
        if n == 0 and m > 0:
            return
        
        i1 = 0
        i2 = 0
        while True:
            toadd1 = None
            toadd2 = None

            if i1 < m:
                toadd1 = nums1[i1]
            if i2 < n:
                toadd2 = nums2[i2]
            if toadd1 is None and toadd2 is None:
                break
            elif toadd2 and toadd1 is None:
                ind = 0
                
                while ind <len(nums1):
                    print(f"3. while {ind}<{len(nums1)} and toadd2:{toadd2} > nums1[{ind}]:{nums1[ind]}")
                    if toadd2 > nums1[ind]:
                        ind +=1
                    else:
                        break
 
                nums1.insert(ind,toadd2)
                i1+=1
                m+=1
                ind2 = ind
                print(f">{ind2}, {ind}, {nums1}")
                while ind2 < len(nums1) and nums1[ind2] != 0:
                    ind2+=1
                
                if ind2 == len(nums1):
                    nums1.pop(ind2-1)
                    print(f"->{nums1}")
                print(f"here3 {nums1}")
            elif toadd1 < toadd2:
                i1+=1
                ind = i1
                while ind <m and toadd2 > nums1[ind]:
                    print(f"1. while {ind}>0 and toadd2:{toadd2} < nums1[{ind}]:{nums1[ind]}")
                    ind += 1

                nums1.insert(ind, toadd2)
                m+=1
                ind2 = ind+1
                while nums1[ind2] != 0 and ind2 < len(nums1):
                    ind2+=1
                nums1.pop(ind2)
            else:
                ind = 0
                
                while ind <=i1:
                    print(f"2. while {ind}>0 and toadd2:{toadd2} < nums1[{ind}]:{nums1[ind]}")
                    if toadd2 > nums1[ind]:
                        ind +=1
                    else:
                        break
 
                print(f"adding {toadd2} to nums[{ind}] = {nums1[ind]}")
                nums1.insert(ind, toadd2)
                i1+=1
                m+=1
                ind2 = ind+1
                while nums1[ind2] != 0 and ind2 < len(nums1):
                    ind2+=1
                
                nums1.pop(ind2)
                print(f"here2 {nums1}")


            i1+=1
            i2+=1
        
