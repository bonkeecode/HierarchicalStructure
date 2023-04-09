public class Branch
{
    public string Name { get; set; }
    public List<Branch> SubBranches { get; set; } = new List<Branch>();

    public Branch(string name)
    {
        Name = name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Branch branch1 = new Branch("branch1");
        Branch branch2 = new Branch("branch2");
        Branch branch3 = new Branch("branch3");
        Branch branch4 = new Branch("branch4");
        Branch branch5 = new Branch("branch5");
        Branch branch6 = new Branch("branch6");
        Branch branch7 = new Branch("branch7");
        Branch branch8 = new Branch("branch8");
        Branch branch9 = new Branch("branch9");
        Branch branch10 = new Branch("branch10");
        Branch branch11 = new Branch("branch11");

        branch1.SubBranches.AddRange(new[] { branch2, branch3 });
        branch2.SubBranches.Add(branch4);
        branch3.SubBranches.AddRange(new[] { branch5, branch6, branch7 });
        branch5.SubBranches.Add(branch8);
        branch6.SubBranches.AddRange(new[] { branch9, branch10 });
        branch9.SubBranches.Add(branch11);

        var depths = new Dictionary<int, List<string>>();
        GetDepths(branch1, 1, depths);

        foreach (var depth in depths)
        {
            Console.WriteLine($"Depth {depth.Key}: {string.Join(", ", depth.Value)}");
        }

        int maxDepth = depths.Keys.Max();
        Console.WriteLine($"Max depth: {maxDepth}");
    }

    static void GetDepths(Branch branch, int depth, Dictionary<int, List<string>> depths)
    {
        if (!depths.ContainsKey(depth))
        {
            depths[depth] = new List<string>();
        }

        depths[depth].Add(branch.Name);

        foreach (var subBranch in branch.SubBranches)
        {
            GetDepths(subBranch, depth + 1, depths);
        }
    }
}
